using System;
using System.Windows;
using Lucy_SalesData.BLL;
using Lucy_SalesData.Models;

namespace LeTruongPhucWPF
{
    public partial class MainWindow : Window
    {
        private ProductBLL productBLL = new ProductBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        private OrderBLL orderBLL = new OrderBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        private EmployeeBLL employeeBLL = new EmployeeBLL();
        private OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

        public MainWindow()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            LoadProducts();
            LoadCustomers();
            LoadOrders();
            LoadCategories();
            LoadEmployees();
            LoadOrderDetails();
        }

        #region Product
        private void LoadProducts()
        {
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = productBLL.GetAll();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtProdID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtProdName.Text) &&
                int.TryParse(txtProdCategoryID.Text, out int catid) &&
                double.TryParse(txtProdPrice.Text, out double price) &&
                int.TryParse(txtProdStock.Text, out int stock))
            {
                var p = new Product
                {
                    ProductID = id,
                    ProductName = txtProdName.Text,
                    CategoryID = catid,
                    UnitPrice = price,
                    UnitsInStock = stock
                };
                productBLL.Add(p);
                LoadProducts();
                ClearProductInput();
            }
            else
            {
                MessageBox.Show("Invalid product input!");
            }
        }

        private void BtnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected &&
                int.TryParse(txtProdID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtProdName.Text) &&
                int.TryParse(txtProdCategoryID.Text, out int catid) &&
                double.TryParse(txtProdPrice.Text, out double price) &&
                int.TryParse(txtProdStock.Text, out int stock))
            {
                var p = new Product
                {
                    ProductID = id,
                    ProductName = txtProdName.Text,
                    CategoryID = catid,
                    UnitPrice = price,
                    UnitsInStock = stock
                };
                productBLL.Update(p);
                LoadProducts();
                ClearProductInput();
            }
            else
            {
                MessageBox.Show("Select a product and fill info to update!");
            }
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product p)
            {
                productBLL.Delete(p.ProductID);
                LoadProducts();
                ClearProductInput();
            }
        }

        private void BtnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchProduct.Text;
            dgProducts.ItemsSource = null;
            dgProducts.ItemsSource = productBLL.Search(keyword);
        }

        private void dgProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product p)
            {
                txtProdID.Text = p.ProductID.ToString();
                txtProdName.Text = p.ProductName;
                txtProdCategoryID.Text = p.CategoryID.ToString();
                txtProdPrice.Text = p.UnitPrice.ToString();
                txtProdStock.Text = p.UnitsInStock.ToString();
            }
        }

        private void ClearProductInput()
        {
            txtProdID.Text = "";
            txtProdName.Text = "";
            txtProdCategoryID.Text = "";
            txtProdPrice.Text = "";
            txtProdStock.Text = "";
        }
        #endregion

        #region Category
        private void LoadCategories()
        {
            dgCategories.ItemsSource = null;
            dgCategories.ItemsSource = categoryBLL.GetAll();
        }

        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCatID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                var c = new Category
                {
                    CategoryID = id,
                    CategoryName = txtCatName.Text,
                    Description = txtCatDesc.Text ?? ""
                };
                categoryBLL.Add(c);
                LoadCategories();
                ClearCategoryInput();
            }
            else
            {
                MessageBox.Show("Invalid category input!");
            }
        }

        private void BtnUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category selected &&
                int.TryParse(txtCatID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtCatName.Text))
            {
                var c = new Category
                {
                    CategoryID = id,
                    CategoryName = txtCatName.Text,
                    Description = txtCatDesc.Text ?? ""
                };
                categoryBLL.Update(c);
                LoadCategories();
                ClearCategoryInput();
            }
            else
            {
                MessageBox.Show("Select a category and fill info to update!");
            }
        }

        private void BtnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category c)
            {
                categoryBLL.Delete(c.CategoryID);
                LoadCategories();
                ClearCategoryInput();
            }
        }

        private void BtnSearchCategory_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchCategory.Text;
            dgCategories.ItemsSource = null;
            dgCategories.ItemsSource = categoryBLL.Search(keyword);
        }

        private void dgCategories_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgCategories.SelectedItem is Category c)
            {
                txtCatID.Text = c.CategoryID.ToString();
                txtCatName.Text = c.CategoryName;
                txtCatDesc.Text = c.Description;
            }
        }

        private void ClearCategoryInput()
        {
            txtCatID.Text = "";
            txtCatName.Text = "";
            txtCatDesc.Text = "";
        }
        #endregion

        #region Customer
        private void LoadCustomers()
        {
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = customerBLL.GetAll();
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCustID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtCustCompany.Text) &&
                !string.IsNullOrWhiteSpace(txtCustContact.Text) &&
                !string.IsNullOrWhiteSpace(txtCustTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtCustAddress.Text) &&
                !string.IsNullOrWhiteSpace(txtCustPhone.Text))
            {
                var c = new Customer
                {
                    CustomerID = id,
                    CompanyName = txtCustCompany.Text,
                    ContactName = txtCustContact.Text,
                    ContactTitle = txtCustTitle.Text,
                    Address = txtCustAddress.Text,
                    Phone = txtCustPhone.Text
                };
                customerBLL.Add(c);
                LoadCustomers();
                ClearCustomerInput();
            }
            else
            {
                MessageBox.Show("Invalid customer input!");
            }
        }

        private void BtnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected &&
                int.TryParse(txtCustID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtCustCompany.Text) &&
                !string.IsNullOrWhiteSpace(txtCustContact.Text) &&
                !string.IsNullOrWhiteSpace(txtCustTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtCustAddress.Text) &&
                !string.IsNullOrWhiteSpace(txtCustPhone.Text))
            {
                var c = new Customer
                {
                    CustomerID = id,
                    CompanyName = txtCustCompany.Text,
                    ContactName = txtCustContact.Text,
                    ContactTitle = txtCustTitle.Text,
                    Address = txtCustAddress.Text,
                    Phone = txtCustPhone.Text
                };
                customerBLL.Update(c);
                LoadCustomers();
                ClearCustomerInput();
            }
            else
            {
                MessageBox.Show("Select a customer and fill info to update!");
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer c)
            {
                customerBLL.Delete(c.CustomerID);
                LoadCustomers();
                ClearCustomerInput();
            }
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchCustomer.Text;
            dgCustomers.ItemsSource = null;
            dgCustomers.ItemsSource = customerBLL.Search(keyword);
        }

        private void dgCustomers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer c)
            {
                txtCustID.Text = c.CustomerID.ToString();
                txtCustCompany.Text = c.CompanyName;
                txtCustContact.Text = c.ContactName;
                txtCustTitle.Text = c.ContactTitle;
                txtCustAddress.Text = c.Address;
                txtCustPhone.Text = c.Phone;
            }
        }

        private void ClearCustomerInput()
        {
            txtCustID.Text = "";
            txtCustCompany.Text = "";
            txtCustContact.Text = "";
            txtCustTitle.Text = "";
            txtCustAddress.Text = "";
            txtCustPhone.Text = "";
        }
        #endregion

        #region Employee
        private void LoadEmployees()
        {
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = employeeBLL.GetAll();
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtEmpID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtEmpName.Text) &&
                !string.IsNullOrWhiteSpace(txtEmpUserName.Text) &&
                !string.IsNullOrWhiteSpace(txtEmpPassword.Password) &&
                !string.IsNullOrWhiteSpace(txtEmpJobTitle.Text))
            {
                var emp = new Employee
                {
                    EmployeeID = id,
                    Name = txtEmpName.Text,
                    UserName = txtEmpUserName.Text,
                    Password = txtEmpPassword.Password,
                    JobTitle = txtEmpJobTitle.Text
                };
                employeeBLL.Add(emp);
                LoadEmployees();
                ClearEmployeeInput();
            }
            else
            {
                MessageBox.Show("Invalid employee input!");
            }
        }

        private void BtnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee selected &&
                int.TryParse(txtEmpID.Text, out int id) &&
                !string.IsNullOrWhiteSpace(txtEmpName.Text) &&
                !string.IsNullOrWhiteSpace(txtEmpUserName.Text) &&
                !string.IsNullOrWhiteSpace(txtEmpPassword.Password) &&
                !string.IsNullOrWhiteSpace(txtEmpJobTitle.Text))
            {
                var emp = new Employee
                {
                    EmployeeID = id,
                    Name = txtEmpName.Text,
                    UserName = txtEmpUserName.Text,
                    Password = txtEmpPassword.Password,
                    JobTitle = txtEmpJobTitle.Text
                };
                employeeBLL.Update(emp);
                LoadEmployees();
                ClearEmployeeInput();
            }
            else
            {
                MessageBox.Show("Select an employee and fill info to update!");
            }
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                employeeBLL.Delete(emp.EmployeeID);
                LoadEmployees();
                ClearEmployeeInput();
            }
        }

        private void BtnSearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchEmployee.Text;
            dgEmployees.ItemsSource = null;
            dgEmployees.ItemsSource = employeeBLL.Search(keyword);
        }

        private void dgEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgEmployees.SelectedItem is Employee emp)
            {
                txtEmpID.Text = emp.EmployeeID.ToString();
                txtEmpName.Text = emp.Name;
                txtEmpUserName.Text = emp.UserName;
                txtEmpPassword.Password = emp.Password;
                txtEmpJobTitle.Text = emp.JobTitle;
            }
        }

        private void ClearEmployeeInput()
        {
            txtEmpID.Text = "";
            txtEmpName.Text = "";
            txtEmpUserName.Text = "";
            txtEmpPassword.Password = "";
            txtEmpJobTitle.Text = "";
        }
        #endregion

        #region Order
        private void LoadOrders()
        {
            dgOrders.ItemsSource = null;
            dgOrders.ItemsSource = orderBLL.GetAll();
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtOrderID.Text, out int oid) &&
                int.TryParse(txtOrderCustID.Text, out int custid) &&
                int.TryParse(txtOrderEmpID.Text, out int empid) &&
                dpOrderDate.SelectedDate.HasValue)
            {
                var cust = customerBLL.GetById(custid);
                if (cust == null)
                {
                    MessageBox.Show("Customer ID không tồn tại!");
                    return;
                }
                var o = new Order
                {
                    OrderID = oid,
                    CustomerID = custid,
                    EmployeeID = empid,
                    OrderDate = dpOrderDate.SelectedDate.Value
                };
                orderBLL.Add(o);
                LoadOrders();
                ClearOrderInput();
            }
            else
            {
                MessageBox.Show("Invalid order input!");
            }
        }

        private void BtnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem is Order selected &&
                int.TryParse(txtOrderID.Text, out int oid) &&
                int.TryParse(txtOrderCustID.Text, out int custid) &&
                int.TryParse(txtOrderEmpID.Text, out int empid) &&
                dpOrderDate.SelectedDate.HasValue)
            {
                var cust = customerBLL.GetById(custid);
                if (cust == null)
                {
                    MessageBox.Show("Customer ID không tồn tại!");
                    return;
                }
                var o = new Order
                {
                    OrderID = oid,
                    CustomerID = custid,
                    EmployeeID = empid,
                    OrderDate = dpOrderDate.SelectedDate.Value
                };
                orderBLL.Update(o);
                LoadOrders();
                ClearOrderInput();
            }
            else
            {
                MessageBox.Show("Select an order and fill info to update!");
            }
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem is Order o)
            {
                orderBLL.Delete(o.OrderID);
                LoadOrders();
                ClearOrderInput();
            }
        }

        private void BtnSearchOrder_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchOrder.Text;
            dgOrders.ItemsSource = null;
            dgOrders.ItemsSource = orderBLL.Search(keyword);
        }

        private void dgOrders_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgOrders.SelectedItem is Order o)
            {
                txtOrderID.Text = o.OrderID.ToString();
                txtOrderCustID.Text = o.CustomerID.ToString();
                txtOrderEmpID.Text = o.EmployeeID.ToString();
                dpOrderDate.SelectedDate = o.OrderDate;
            }
        }

        private void ClearOrderInput()
        {
            txtOrderID.Text = "";
            txtOrderCustID.Text = "";
            txtOrderEmpID.Text = "";
            dpOrderDate.SelectedDate = null;
        }
        #endregion

        #region OrderDetail
        private void LoadOrderDetails()
        {
            dgOrderDetails.ItemsSource = null;
            dgOrderDetails.ItemsSource = orderDetailBLL.GetAll();
        }

        private void BtnAddOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtODOrderID.Text, out int orderId) &&
                int.TryParse(txtODProdID.Text, out int prodId) &&
                double.TryParse(txtODUnitPrice.Text, out double unitPrice) &&
                int.TryParse(txtODQuantity.Text, out int quantity) &&
                float.TryParse(txtODDiscount.Text, out float discount))
            {
                var od = new OrderDetail
                {
                    OrderID = orderId,
                    ProductID = prodId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount
                };
                orderDetailBLL.Add(od);
                LoadOrderDetails();
                ClearOrderDetailInput();
            }
            else
            {
                MessageBox.Show("Invalid order detail input!");
            }
        }

        private void BtnUpdateOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderDetails.SelectedItem is OrderDetail selected &&
                int.TryParse(txtODOrderID.Text, out int orderId) &&
                int.TryParse(txtODProdID.Text, out int prodId) &&
                double.TryParse(txtODUnitPrice.Text, out double unitPrice) &&
                int.TryParse(txtODQuantity.Text, out int quantity) &&
                float.TryParse(txtODDiscount.Text, out float discount))
            {
                var od = new OrderDetail
                {
                    OrderID = orderId,
                    ProductID = prodId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount
                };
                orderDetailBLL.Update(od);
                LoadOrderDetails();
                ClearOrderDetailInput();
            }
            else
            {
                MessageBox.Show("Select an order detail and fill info to update!");
            }
        }

        private void BtnDeleteOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrderDetails.SelectedItem is OrderDetail od)
            {
                orderDetailBLL.Delete(od.OrderID, od.ProductID);
                LoadOrderDetails();
                ClearOrderDetailInput();
            }
        }

        private void BtnSearchOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchOrderDetail.Text;
            dgOrderDetails.ItemsSource = null;
            dgOrderDetails.ItemsSource = orderDetailBLL.Search(keyword);
        }

        private void dgOrderDetails_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgOrderDetails.SelectedItem is OrderDetail od)
            {
                txtODOrderID.Text = od.OrderID.ToString();
                txtODProdID.Text = od.ProductID.ToString();
                txtODUnitPrice.Text = od.UnitPrice.ToString();
                txtODQuantity.Text = od.Quantity.ToString();
                txtODDiscount.Text = od.Discount.ToString();
            }
        }

        private void ClearOrderDetailInput()
        {
            txtODOrderID.Text = "";
            txtODProdID.Text = "";
            txtODUnitPrice.Text = "";
            txtODQuantity.Text = "";
            txtODDiscount.Text = "";
        }
        #endregion

        private void txtODDiscount_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}