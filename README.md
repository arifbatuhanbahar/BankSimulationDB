<<<<<<< HEAD
# 🏦 Bank Simulation Frontend

Modern React frontend for Bank Simulation API.

## 🚀 Quick Start

```bash
cd bank-simulation-frontend
npm install
npm run dev
```

Open http://localhost:3000

## 📦 Tech Stack

- React 19 + TypeScript
- Vite 7 (Build Tool)
- Material-UI 7 (Components)
- React Router 7 (Routing)
- React Query 5 (Data Fetching)
- React Hook Form + Yup (Forms)
- Axios (HTTP Client)
- Tailwind CSS 4 (Styling)

## 📁 Structure

```
src/
├── api/          # API services
├── components/   # Reusable components
├── features/     # Feature modules
├── hooks/        # Custom hooks
├── types/        # TypeScript types
├── utils/        # Helpers
└── routes/       # Router config
```

## 🔧 Configuration

Edit `.env.development`:

```env
VITE_API_BASE_URL=http://localhost:5161/api
```

## 📝 Scripts

```bash
npm run dev      # Dev server (port 3000)
npm run build    # Production build
npm run preview  # Preview build
npm run lint     # Lint code
```

## ✅ Completed Pages

- Login Page
- Dashboard
- Layout (Header, Sidebar)

## 🔄 In Progress

- Accounts, Transactions, Cards
- Transfer, Card Application
- KYC, KVKK, Admin Panel
=======
# 🏦 Bank Simulation - VTYS Ders Projesi

Veritabanı Yönetim Sistemleri dersi için geliştirilmiş kapsamlı bir banka simülasyonu projesidir.

## 📊 Proje Özeti

| Özellik | Değer |
|---------|-------|
| **Toplam Tablo** | 38 |
| **Toplam Modül** | 9 |
| **Teknoloji** | .NET 8, Dapper, SQL Server |
| **Mimari** | Clean Architecture |
| **ORM** | Dapper (Pure SQL) |

---

## 🏗️ Modüller ve Tablolar

### Modül 1: User Management (5 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `users` | Kullanıcı bilgileri (TC, ad, soyad, email, şifre hash) |
| `user_roles` | Kullanıcı rolleri (Customer, Employee, Admin) |
| `user_sessions` | Oturum yönetimi (token, IP, cihaz bilgisi) |
| `login_attempts` | Giriş denemeleri (başarılı/başarısız) |
| `password_history` | Şifre geçmişi (son 5 şifre saklanır) |

### Modül 2: Account Management (4 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `account_types` | Hesap türleri (Vadesiz, Vadeli, Tasarruf, Döviz) |
| `accounts` | Banka hesapları (IBAN, bakiye, limit) |
| `account_beneficiaries` | Kayıtlı alıcılar |
| `account_limits` | Hesap limitleri (günlük, aylık) |

### Modül 3: Transaction Management (6 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `transaction_types` | İşlem türleri (FAST, EFT, Havale, SWIFT) |
| `transactions` | Ana işlem tablosu (transfer, ödeme) |
| `transaction_fees` | İşlem ücretleri |
| `scheduled_transactions` | Planlanmış/otomatik işlemler |
| `transaction_approvals` | Yüksek tutarlı işlem onayları |
| `general_ledger` | Muhasebe kayıtları (çift taraflı kayıt) |

### Modül 4: Payment & Cards (5 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `credit_cards` | Kredi kartları (şifreli kart no, limit) |
| `card_transactions` | Kart harcamaları |
| `payment_methods` | Kayıtlı ödeme yöntemleri |
| `recurring_payments` | Düzenli ödemeler (Netflix, fatura) |
| `payment_gateways` | Ödeme sağlayıcıları (iyzico, PayTR) |

### Modül 5: Compliance & KYC (6 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `kyc_documents` | KYC belgeleri (kimlik, pasaport) |
| `kyc_verifications` | Doğrulama işlemleri (SMS, email) |
| `kvkk_consents` | KVKK onayları |
| `kvkk_data_requests` | Veri talepleri (silme, düzeltme) |
| `masak_records` | MASAK kayıtları |
| `suspicious_activity_reports` | Şüpheli işlem raporları (SAR) |

### Modül 6: Audit & Security (5 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `audit_logs` | Denetim kayıtları (tüm değişiklikler) |
| `security_events` | Güvenlik olayları (brute force, vb.) |
| `data_access_log` | Veri erişim kaydı |
| `pci_audit_log` | PCI-DSS uyumlu kart erişim logları |
| `encryption_keys` | Şifreleme anahtarları |

### Modül 7: Fraud & Risk (3 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `fraud_rules` | Dolandırıcılık kuralları |
| `fraud_alerts` | Fraud alarmları |
| `risk_profiles` | Kullanıcı risk profilleri |

### Modül 8: System & Configuration (2 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `system_settings` | Sistem ayarları |
| `notification_templates` | Bildirim şablonları (email, SMS) |

### Modül 9: Credit Card Applications (2 Tablo)
| Tablo | Açıklama |
|-------|----------|
| `card_applications` | Kart başvuruları |
| `card_limits` | Kart limitleri (online, temassız) |

---

## 🛠️ Teknoloji Stack

| Katman | Teknoloji |
|--------|-----------|
| **Backend** | .NET 8, ASP.NET Core Web API |
| **Veritabanı** | Microsoft SQL Server |
| **ORM** | Dapper (Pure SQL Queries) |
| **Test Verisi** | Bogus Library |
| **API Docs** | Swagger / OpenAPI |
| **Mimari** | Clean Architecture |

---

## 📁 Proje Yapısı

```
BankSimulation/
├── src/
│   ├── BankSimulation.API/              # Web API Katmanı
│   │   ├── Controllers/
│   │   │   ├── UsersController.cs
│   │   │   ├── AccountsController.cs
│   │   │   ├── TransactionsController.cs
│   │   │   ├── PaymentsController.cs
│   │   │   ├── ComplianceController.cs
│   │   │   ├── AuditController.cs
│   │   │   ├── FraudController.cs
│   │   │   ├── SystemController.cs
│   │   │   ├── ApplicationController.cs
│   │   │   └── SeederController.cs
│   │   ├── Services/
│   │   │   └── DataSeeder.cs            # Bogus ile test verisi
│   │   └── Program.cs
│   │
│   ├── BankSimulation.Domain/           # Domain Katmanı
│   │   └── Entities/                    # 38 Entity sınıfı
│   │
│   └── BankSimulation.Infrastructure/   # Altyapı Katmanı
│       └── Data/
│           └── DapperContext.cs         # Veritabanı bağlantısı
│
├── BankSimulationDb_Clean.sql           # Veritabanı scripti
└── README.md
```

---

## 🚀 Kurulum

### 1. Gereksinimler
- .NET 8 SDK
- SQL Server (Express veya üzeri)
- Visual Studio 2022 / VS Code

### 2. Veritabanı Oluşturma
SQL Server Management Studio'da `BankSimulationDb_Clean.sql` dosyasını çalıştırın.

### 3. Connection String
`appsettings.json` dosyasında bağlantı stringini düzenleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=BankSimulationDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

### 4. Projeyi Çalıştırma
```bash
cd C:\Projects\BankSimulation
dotnet run --project src/BankSimulation.API
```

### 5. Swagger UI
Tarayıcıda açın:
```
http://localhost:5161/swagger
```

---

## 📊 Test Verisi Ekleme

Swagger üzerinden aşağıdaki endpoint'leri kullanabilirsiniz:

| Endpoint | Metod | Açıklama |
|----------|-------|----------|
| `/api/Seeder/seed-all` | POST | Tüm tablolara veri ekler |
| `/api/Seeder/stats` | GET | İstatistikleri görüntüler |
| `/api/Seeder/table-counts` | GET | Tablo bazında kayıt sayıları |
| `/api/Seeder/clear-all` | DELETE | Tüm verileri siler |

### Eklenen Test Verisi Miktarları

| Tablo | Kayıt Sayısı |
|-------|--------------|
| users | 100 |
| user_roles | 100 |
| user_sessions | 300 |
| login_attempts | 500 |
| password_history | ~300 |
| accounts | ~200 |
| account_beneficiaries | 200 |
| account_limits | ~600 |
| transactions | 1000 |
| transaction_fees | ~350 |
| scheduled_transactions | 100 |
| general_ledger | ~600 |
| credit_cards | 60 |
| card_transactions | 500 |
| payment_methods | ~100 |
| recurring_payments | 80 |
| kyc_documents | 100 |
| kyc_verifications | ~300 |
| kvkk_consents | 300 |
| audit_logs | 1000 |
| security_events | 300 |
| data_access_log | 500 |
| pci_audit_log | 200 |
| fraud_rules | 8 |
| fraud_alerts | 50 |
| risk_profiles | 100 |
| masak_records | 50 |
| suspicious_activity_reports | 25 |
| card_applications | 80 |
| card_limits | ~240 |
| **TOPLAM** | **~7500+** |

---

## 🔒 Güvenlik Özellikleri

- ✅ **Şifre Güvenliği:** SHA256 + Salt ile hashleme
- ✅ **Kart Güvenliği:** Base64 ile şifreleme
- ✅ **Audit Trail:** Tüm değişikliklerin loglanması
- ✅ **PCI-DSS:** Kart erişim logları
- ✅ **KVKK:** Veri işleme onayları ve talep yönetimi
- ✅ **MASAK:** Şüpheli işlem raporlama (75.000 TL üzeri)
- ✅ **Fraud Detection:** 8 farklı kural ile dolandırıcılık tespiti

---

## 📈 API Endpoint'leri

### Users Controller
| Metod | Endpoint | Açıklama |
|-------|----------|----------|
| GET | `/api/Users` | Tüm kullanıcıları listele |
| GET | `/api/Users/{id}` | Kullanıcı detayı |
| POST | `/api/Users` | Yeni kullanıcı oluştur |
| PUT | `/api/Users/{id}` | Kullanıcı güncelle |

### Accounts Controller
| Metod | Endpoint | Açıklama |
|-------|----------|----------|
| GET | `/api/Accounts` | Tüm hesapları listele |
| GET | `/api/Accounts/{id}` | Hesap detayı |
| GET | `/api/Accounts/user/{userId}` | Kullanıcının hesapları |
| POST | `/api/Accounts` | Yeni hesap oluştur |
| PUT | `/api/Accounts/{id}/status` | Hesap durumu güncelle |

### Transactions Controller
| Metod | Endpoint | Açıklama |
|-------|----------|----------|
| GET | `/api/Transactions` | Tüm işlemleri listele |
| POST | `/api/Transactions/transfer` | Para transferi yap |

### Diğer Controller'lar
- **Payments:** Kart işlemleri, düzenli ödemeler
- **Compliance:** KYC belgeleri, KVKK talepleri
- **Audit:** Denetim logları, güvenlik olayları
- **Fraud:** Fraud kuralları, alarmlar
- **System:** Sistem ayarları, bildirim şablonları

---

## 📝 Örnek SQL Sorguları

### 1. Kullanıcı ve Hesap Bilgileri (INNER JOIN)
```sql
SELECT 
    u.first_name + ' ' + u.last_name AS FullName,
    u.email,
    a.account_number,
    a.currency,
    a.balance
FROM users u
INNER JOIN accounts a ON u.user_id = a.user_id
WHERE a.status = 'Active'
ORDER BY a.balance DESC;
```

### 2. Para Birimi Bazında Toplam Bakiye (GROUP BY + HAVING)
```sql
SELECT 
    currency,
    COUNT(*) AS HesapSayisi,
    SUM(balance) AS ToplamBakiye,
    AVG(balance) AS OrtalamaBakiye
FROM accounts
WHERE status = 'Active'
GROUP BY currency
HAVING SUM(balance) > 0
ORDER BY ToplamBakiye DESC;
```

### 3. Şüpheli İşlemler (Multi-table JOIN)
```sql
SELECT 
    t.transaction_id,
    t.amount,
    t.fraud_score,
    t.transaction_date,
    u.first_name + ' ' + u.last_name AS Kullanici,
    a.account_number AS GonderenHesap
FROM transactions t
INNER JOIN accounts a ON t.from_account_id = a.account_id
INNER JOIN users u ON a.user_id = u.user_id
WHERE t.fraud_score > 70
ORDER BY t.fraud_score DESC, t.transaction_date DESC;
```

### 4. Kullanıcı Risk Analizi (LEFT JOIN)
```sql
SELECT 
    u.first_name + ' ' + u.last_name AS Kullanici,
    u.kyc_status,
    u.risk_level,
    rp.transaction_velocity_score,
    rp.amount_anomaly_score,
    rp.behavioral_score
FROM users u
LEFT JOIN risk_profiles rp ON u.user_id = rp.user_id
WHERE u.risk_level IN ('Medium', 'High')
ORDER BY rp.behavioral_score DESC;
```

### 5. Aylık İşlem Özeti (Subquery)
```sql
SELECT 
    YEAR(transaction_date) AS Yil,
    MONTH(transaction_date) AS Ay,
    COUNT(*) AS IslemSayisi,
    SUM(amount) AS ToplamTutar,
    AVG(amount) AS OrtalamaIslem
FROM transactions
WHERE status = 'Completed'
    AND transaction_date >= DATEADD(MONTH, -12, GETDATE())
GROUP BY YEAR(transaction_date), MONTH(transaction_date)
ORDER BY Yil DESC, Ay DESC;
```

### 6. En Çok Harcama Yapan Kartlar (TOP + JOIN)
```sql
SELECT TOP 10
    cc.card_last_four,
    cc.card_brand,
    u.first_name + ' ' + u.last_name AS KartSahibi,
    COUNT(ct.card_transaction_id) AS IslemSayisi,
    SUM(ct.amount) AS ToplamHarcama
FROM credit_cards cc
INNER JOIN users u ON cc.user_id = u.user_id
INNER JOIN card_transactions ct ON cc.card_id = ct.card_id
WHERE ct.status = 'Approved'
GROUP BY cc.card_id, cc.card_last_four, cc.card_brand, u.first_name, u.last_name
ORDER BY ToplamHarcama DESC;
```

### 7. MASAK Bildirim Gerektiren İşlemler
```sql
SELECT 
    t.reference_number,
    t.amount,
    t.transaction_date,
    u.tc_kimlik_no,
    u.first_name + ' ' + u.last_name AS Kullanici
FROM transactions t
INNER JOIN accounts a ON t.from_account_id = a.account_id
INNER JOIN users u ON a.user_id = u.user_id
WHERE t.amount >= 75000
    AND t.reported_to_masak = 0
    AND t.status = 'Completed';
```

### 8. Günlük Giriş İstatistikleri
```sql
SELECT 
    CAST(attempted_at AS DATE) AS Tarih,
    COUNT(*) AS ToplamDeneme,
    SUM(CASE WHEN success = 1 THEN 1 ELSE 0 END) AS BasariliGiris,
    SUM(CASE WHEN success = 0 THEN 1 ELSE 0 END) AS BasarisizGiris,
    CAST(SUM(CASE WHEN success = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS BasariOrani
FROM login_attempts
WHERE attempted_at >= DATEADD(DAY, -30, GETDATE())
GROUP BY CAST(attempted_at AS DATE)
ORDER BY Tarih DESC;
```

### 9. Hesap Türü Dağılımı
```sql
SELECT 
    at.type_name AS HesapTuru,
    COUNT(a.account_id) AS HesapSayisi,
    SUM(a.balance) AS ToplamBakiye,
    at.interest_rate AS FaizOrani
FROM account_types at
LEFT JOIN accounts a ON at.type_name = a.account_type
GROUP BY at.type_id, at.type_name, at.interest_rate
ORDER BY HesapSayisi DESC;
```

### 10. Fraud Alarm Özeti
```sql
SELECT 
    alert_severity AS OnemDerecesi,
    status AS Durum,
    COUNT(*) AS AlarmSayisi,
    AVG(fraud_score) AS OrtalamaFraudSkoru
FROM fraud_alerts
GROUP BY alert_severity, status
ORDER BY 
    CASE alert_severity 
        WHEN 'Critical' THEN 1 
        WHEN 'High' THEN 2 
        WHEN 'Medium' THEN 3 
        ELSE 4 
    END;
```

---

## 🔗 ER Diyagramı

38 tablo arasındaki ilişkiler:

```
users (1) ────────< (N) accounts
users (1) ────────< (N) user_roles
users (1) ────────< (N) user_sessions
users (1) ────────< (N) login_attempts
users (1) ────────< (N) credit_cards
users (1) ────────< (N) kyc_documents
users (1) ────────< (N) risk_profiles

accounts (1) ────────< (N) transactions (from)
accounts (1) ────────< (N) transactions (to)
accounts (1) ────────< (N) account_beneficiaries
accounts (1) ────────< (N) account_limits

credit_cards (1) ────────< (N) card_transactions
credit_cards (1) ────────< (N) card_limits

transactions (1) ────────< (N) transaction_fees
transactions (1) ────────< (N) transaction_approvals
transactions (1) ────────< (N) general_ledger
transactions (1) ────────< (N) fraud_alerts
```

---

## 👨‍💻 Geliştirici

**Arif Batuhan Bahar**

- 📧 Email: arifbatuhanbahar@gmail.com
- 🔗 GitHub: [github.com/arifbatuhanbahar](https://github.com/arifbatuhanbahar)

---

## 📄 Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| **Ders** | Veritabanı Yönetim Sistemleri |
| **Dönem** | 2024-2025 Güz |
| **Proje Ağırlığı** | %25 |

---

## 📜 Lisans

Bu proje eğitim amaçlı geliştirilmiştir. Tüm hakları saklıdır.
>>>>>>> c52f38daac56e772af59183e1a3ddbefb149171c
