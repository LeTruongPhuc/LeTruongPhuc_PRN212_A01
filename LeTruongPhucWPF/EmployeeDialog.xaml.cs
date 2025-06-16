using System.Windows;
using Lucy_SalesData.Models;

namespace LeTruongPhucWPF
{
    public partial class EmployeeDialog : Window
    {
        public Employee Employee { get; private set; }

        public EmployeeDialog(Employee emp = null)
        {
            InitializeComponent();
            if (emp != null)
            {
                Employee = new Employee
                {
                    EmployeeID = emp.EmployeeID,
                    Name = emp.Name,
                    UserName = emp.UserName,
                    Password = emp.Password,
                    JobTitle = emp.JobTitle
                };
                txtName.Text = emp.Name;
                txtUserName.Text = emp.UserName;
                txtPassword.Password = emp.Password;
                txtJobTitle.Text = emp.JobTitle;
            }
            else
            {
                Employee = new Employee();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Employee.Name = txtName.Text.Trim();
            Employee.UserName = txtUserName.Text.Trim();
            Employee.Password = txtPassword.Password.Trim();
            Employee.JobTitle = txtJobTitle.Text.Trim();

            if (string.IsNullOrWhiteSpace(Employee.Name) ||
                string.IsNullOrWhiteSpace(Employee.UserName) ||
                string.IsNullOrWhiteSpace(Employee.Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi");
                return;
            }

            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}