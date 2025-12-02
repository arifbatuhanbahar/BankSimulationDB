using BankSimulation.Domain.Entities.Compliance;
using BankSimulation.Domain.Enums;
using BankSimulation.Infrastructure.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComplianceController : ControllerBase
{
    private readonly DapperContext _context;

    public ComplianceController(DapperContext context)
    {
        _context = context;
        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    [HttpPost("upload-document")]
    public async Task<ActionResult<KycDocument>> UploadDocument(KycDocumentRequest request)
    {
        using var connection = _context.CreateConnection();

        var sql = @"
            INSERT INTO kyc_documents (
                user_id, document_type, document_number, document_file_path, 
                document_hash, upload_date, verification_status
            )
            VALUES (
                @UserId, @DocumentType, @DocumentNumber, @FilePath, 
                'A1B2C3D4', GETDATE(), 'Pending'
            );
            SELECT CAST(SCOPE_IDENTITY() as int);";

        var filePath = $"/uploads/users/{request.UserId}/{Guid.NewGuid()}.pdf";
        
        var id = await connection.QuerySingleAsync<int>(sql, new { 
            request.UserId, 
            DocumentType = request.DocumentType.ToString(), 
            request.DocumentNumber, 
            FilePath = filePath 
        });

        return Ok(new { Message = "Belge yüklendi", DocumentId = id });
    }

    [HttpPost("verify-document")]
    public async Task<IActionResult> VerifyDocument(int documentId, bool isApproved, string? rejectionReason)
    {
        using var connection = _context.CreateConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        try 
        {
            var status = isApproved ? VerificationStatus.Verified.ToString() : VerificationStatus.Rejected.ToString();

            var updateDocSql = @"
                UPDATE kyc_documents 
                SET verification_status = @Status, 
                    verified_at = GETDATE(), 
                    rejection_reason = @Reason, 
                    verified_by = 1 
                WHERE document_id = @Id";
            
            await connection.ExecuteAsync(updateDocSql, new { Status = status, Reason = rejectionReason, Id = documentId }, transaction);

            if (isApproved)
            {
                var userId = await connection.QuerySingleAsync<int>("SELECT user_id FROM kyc_documents WHERE document_id = @Id", new { Id = documentId }, transaction);
                var updateUserSql = "UPDATE users SET kyc_status = 'Verified' WHERE user_id = @UserId";
                await connection.ExecuteAsync(updateUserSql, new { UserId = userId }, transaction);
            }

            transaction.Commit();
            return Ok($"Belge durumu güncellendi: {status}");
        }
        catch
        {
            transaction.Rollback();
            return StatusCode(500, "Onaylama hatası");
        }
    }

    [HttpPost("report-suspicious-activity")]
    public async Task<IActionResult> ReportActivity(SarRequest request)
    {
        using var connection = _context.CreateConnection();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        try
        {
            var riskScore = 85;
            var isMasak = riskScore > 80;

            var sarSql = @"
                INSERT INTO suspicious_activity_reports (
                    user_id, transaction_id, report_type, description, risk_score, 
                    status, created_at, created_by, reported_to_masak, masak_report_date
                )
                VALUES (
                    @UserId, @TransactionId, @ReportType, @Description, @RiskScore, 
                    'Draft', GETDATE(), 1, @IsMasak, @MasakDate
                );
                SELECT CAST(SCOPE_IDENTITY() as int);";

            var sarId = await connection.QuerySingleAsync<int>(sarSql, new {
                request.UserId, request.TransactionId, 
                ReportType = request.ReportType.ToString(), 
                request.Description, RiskScore = riskScore,
                IsMasak = isMasak, MasakDate = isMasak ? (DateTime?)DateTime.Now : null
            }, transaction);

            if (isMasak)
            {
                var masakSql = @"
                    INSERT INTO masak_records (
                        customer_id, transaction_id, record_type, data, 
                        created_at, retention_until
                    )
                    VALUES (
                        @UserId, @TransactionId, 'SuspiciousReport', 
                        @Data, GETDATE(), DATEADD(year, 10, GETDATE())
                    );";
                
                await connection.ExecuteAsync(masakSql, new {
                    request.UserId, request.TransactionId,
                    Data = $"{{ 'reason': '{request.Description}', 'sar_id': {sarId} }}"
                }, transaction);
            }

            transaction.Commit();
            return Ok(new { Message = "Bildirim yapıldı", ReportId = sarId });
        }
        catch
        {
            transaction.Rollback();
            return StatusCode(500, "Raporlama hatası");
        }
    }
}

public class KycDocumentRequest
{
    public int UserId { get; set; }
    public DocumentType DocumentType { get; set; }
    public string DocumentNumber { get; set; } = null!;
}

public class SarRequest
{
    public int UserId { get; set; }
    public int? TransactionId { get; set; }
    public SarReportType ReportType { get; set; }
    public string Description { get; set; } = null!;
}