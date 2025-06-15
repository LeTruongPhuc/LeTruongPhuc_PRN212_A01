using System;
using System.Linq;
using System.Windows;

namespace LeTruongPhucWPF
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Password.Trim();

            try
            {
                using (var db = new Lucy_SalesDataEntities())
                {
                    // (Tùy chỉnh lại tên thuộc tính UserName, Password nếu khác)
                    var user = db.Employees
                        .FirstOrDefault(u => u.UserName == username && u.Password == password);

                    if (user != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        // Mở form chính hoặc chuyển tiếp tùy ý
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập hoặc kết nối database:\n" + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}