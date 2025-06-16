using System;
using System.Windows;
using System.Linq;
using Lucy_SalesData.BLL;
using Lucy_SalesData.Models;

namespace LeTruongPhucWPF
{
    public partial class MainWindow : Window
    {
        private ProductBLL productBLL = new ProductBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private OrderBLL orderBLL = new OrderBLL();
        private OrderDetailBLL orderDetailBLL = new OrderDetailBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();

        public MainWindow()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            dgProducts.ItemsSource = productBLL.GetAll().ToList();
            dgCustomers.ItemsSource = customerBLL.GetAll().ToList();
            dgCategories.ItemsSource = categoryBLL.GetAll().ToList();
            dgOrders.ItemsSource = orderBLL.GetAll().ToList();
            dgOrderDetails.ItemsSource = orderDetailBLL.GetAll().ToList();
            dgEmployees.ItemsSource = employeeBLL.GetAll().ToList();
        }

        // --- PRODUCT EVENTS ---
        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var prod = new Product
                {
                    ProductID = int.Parse(txtProdID.Text),
                    ProductName = txtProdName.Text,
                    CategoryID = int.Parse(txtProdCategory.Text),
                    UnitPrice = double.Parse(txtProdPrice.Text),
                    UnitsInStock = int.Parse(txtProdStock.Text)
                };
                productBLL.Add(prod);
                dgProducts.ItemsSource = productBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product prod)
            {
                productBLL.Delete(prod.ProductID);
                dgProducts.ItemsSource = productBLL.GetAll().ToList();
            }
        }

        // --- CUSTOMER EVENTS ---
        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cus = new Customer
                {
                    CustomerID = int.Parse(txtCustID.Text),
                    CompanyName = txtCustCompany.Text,
                    ContactName = txtCustContact.Text,
                    ContactTitle = txtCustTitle.Text,
                    Address = txtCustAddress.Text,
                    Phone = txtCustPhone.Text
                };
                customerBLL.Add(cus);
                dgCustomers.ItemsSource = customerBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer cus)
            {
                customerBLL.Delete(cus.CustomerID);
                dgCustomers.ItemsSource = customerBLL.GetAll().ToList();
            }
        }

        // --- CATEGORY EVENTS ---
        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cat = new Category
                {
                    CategoryID = int.Parse(txtCatID.Text),
                    CategoryName = txtCatName.Text,
                    Description = txtCatDesc.Text
                };
                categoryBLL.Add(cat);
                dgCategories.ItemsSource = categoryBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category cat)
            {
                categoryBLL.Delete(cat.CategoryID);
                dgCategories.ItemsSource = categoryBLL.GetAll().ToList();
            }
        }

        // --- ORDER EVENTS ---
        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = new Order
                {
                    OrderID = int.Parse(txtOrderID.Text),
                    CustomerID = int.Parse(txtOrderCustID.Text),
                    EmployeeID = int.Parse(txtOrderEmpID.Text),
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now
                };
                orderBLL.Add(order);
                dgOrders.ItemsSource = orderBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem is Order order)
            {
                orderBLL.Delete(order.OrderID);
                dgOrders.ItemsSource = orderBLL.GetAll().ToList();
            }
        }

        // --- ORDER DETAIL EVENTS ---
        private void BtnAddOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var od = new OrderDetail
                {
                    OrderID = int.Parse(txtODOrderID.Text),
                    ProductID = int.Parse(txtODProdID.Text),
                    UnitPrice = double.Parse(txtODUnitPrice.Text),
                    Quantity = int.Parse(txtODQuantity.Text),
                    Discount = double.Parse(txtODDiscount.Text)
                };
                orderDetailBLL.Add(od);
                dgOrderDetails.ItemsSource = orderDetailBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderDetails.SelectedItem is OrderDetail od)
            {
                orderDetailBLL.Delete(od.OrderID, od.ProductID);
                dgOrderDetails.ItemsSource = orderDetailBLL.GetAll().ToList();
            }
        }

        // --- EMPLOYEE EVENTS ---
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var emp = new Employee
                {
                    EmployeeID = int.Parse(txtEmpID.Text),
                    Name = txtEmpName.Text,
                    UserName = txtEmpUser.Text,
                    Password = txtEmpPass.Text,
                    JobTitle = txtEmpJob.Text
                };
                employeeBLL.Add(emp);
                dgEmployees.ItemsSource = employeeBLL.GetAll().ToList();
            }
            catch { MessageBox.Show("Nhập liệu không hợp lệ!"); }
        }
        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                employeeBLL.Delete(emp.EmployeeID);
                dgEmployees.ItemsSource = employeeBLL.GetAll().ToList();
            }
        }
    }
}