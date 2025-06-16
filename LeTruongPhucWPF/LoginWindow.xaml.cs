using System.Windows;
using Lucy_SalesData.BLL;

namespace LeTruongPhucWPF
{
    public partial class LoginWindow : Window
    {
        private EmployeeBLL _employeeBLL = new EmployeeBLL();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Password.Trim();

            var user = _employeeBLL.Login(username, password);
            if (user != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}