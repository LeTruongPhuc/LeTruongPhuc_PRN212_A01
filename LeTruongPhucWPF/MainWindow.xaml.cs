using System.Linq;
using System.Windows;
using Lucy_SalesData.BLL;
using Lucy_SalesData.Models;

namespace LeTruongPhucWPF
{
    public partial class MainWindow : Window
    {
        private EmployeeBLL _employeeBLL = new EmployeeBLL();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            if (string.IsNullOrWhiteSpace(keyword))
                dgEmployees.ItemsSource = _employeeBLL.GetAll().ToList();
            else
                dgEmployees.ItemsSource = _employeeBLL.Search(keyword).ToList();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new EmployeeDialog();
            if (dlg.ShowDialog() == true)
            {
                _employeeBLL.Add(dlg.Employee);
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                var dlg = new EmployeeDialog(emp);
                if (dlg.ShowDialog() == true)
                {
                    _employeeBLL.Update(dlg.Employee);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên để sửa!", "Thông báo");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                if (MessageBox.Show($"Xóa nhân viên '{emp.Name}'?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _employeeBLL.Delete(emp.EmployeeID);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên để xóa!", "Thông báo");
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}