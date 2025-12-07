import { createBrowserRouter, Navigate } from 'react-router-dom';
import { MainLayout } from '../components/layout';
import PrivateRoute from './PrivateRoute';

// Auth Pages
import LoginPage from '../features/auth/pages/LoginPage';

// Dashboard
import DashboardPage from '../features/dashboard/pages/DashboardPage';

// Placeholder component for pages not yet created
const ComingSoon = ({ title }: { title: string }) => (
  <div style={{ padding: '40px', textAlign: 'center' }}>
    <h2>{title}</h2>
    <p>Bu sayfa henüz geliştirme aşamasında...</p>
  </div>
);

// Get user from localStorage
const getUser = () => {
  const userJson = localStorage.getItem('user');
  return userJson ? JSON.parse(userJson) : null;
};

const router = createBrowserRouter([
  // Public Routes
  {
    path: '/login',
    element: <LoginPage />,
  },
  {
    path: '/register',
    element: <ComingSoon title="Kayıt Sayfası" />,
  },

  // Protected Routes
  {
    path: '/',
    element: (
      <PrivateRoute>
        <MainLayout user={getUser()} />
      </PrivateRoute>
    ),
    children: [
      {
        index: true,
        element: <Navigate to="/dashboard" replace />,
      },
      {
        path: 'dashboard',
        element: <DashboardPage />,
      },
      {
        path: 'accounts',
        element: <ComingSoon title="Hesaplarım" />,
      },
      {
        path: 'accounts/:id',
        element: <ComingSoon title="Hesap Detayı" />,
      },
      {
        path: 'transactions',
        element: <ComingSoon title="İşlem Geçmişi" />,
      },
      {
        path: 'transfer',
        element: <ComingSoon title="Para Transferi" />,
      },
      {
        path: 'cards',
        element: <ComingSoon title="Kartlarım" />,
      },
      {
        path: 'cards/apply',
        element: <ComingSoon title="Kart Başvurusu" />,
      },
      {
        path: 'cards/:id',
        element: <ComingSoon title="Kart Detayı" />,
      },
      {
        path: 'compliance/kyc',
        element: <ComingSoon title="KYC Belgeleri" />,
      },
      {
        path: 'compliance/kvkk',
        element: <ComingSoon title="KVKK Yönetimi" />,
      },
      {
        path: 'profile',
        element: <ComingSoon title="Profilim" />,
      },
      {
        path: 'settings',
        element: <ComingSoon title="Ayarlar" />,
      },
      // Admin Routes
      {
        path: 'admin/users',
        element: <ComingSoon title="Kullanıcı Yönetimi" />,
      },
      {
        path: 'admin/fraud',
        element: <ComingSoon title="Fraud Alarmları" />,
      },
      {
        path: 'admin/audit',
        element: <ComingSoon title="Audit Logs" />,
      },
    ],
  },

  // 404 Page
  {
    path: '*',
    element: (
      <div style={{ padding: '40px', textAlign: 'center' }}>
        <h1>404</h1>
        <p>Sayfa Bulunamadı</p>
        <a href="/dashboard">Ana Sayfaya Dön</a>
      </div>
    ),
  },
]);

export default router;
