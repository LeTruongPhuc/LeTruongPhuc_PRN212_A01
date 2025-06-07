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
                double.TryParse(txtProdPrice.Text, out double price) &&
                int.TryParse(txtProdStock.Text, out int stock))
            {
                var p = new Product { ProductID = id, Name = txtProdName.Text, Price = price, Stock = stock };
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
                double.TryParse(txtProdPrice.Text, out double price) &&
                int.TryParse(txtProdStock.Text, out int stock))
            {
                var p = new Product { ProductID = id, Name = txtProdName.Text, Price = price, Stock = stock };
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
                txtProdName.Text = p.Name;
                txtProdPrice.Text = p.Price.ToString();
                txtProdStock.Text = p.Stock.ToString();
            }
        }

        private void ClearProductInput()
        {
            txtProdID.Text = "";
            txtProdName.Text = "";
            txtProdPrice.Text = "";
            txtProdStock.Text = "";
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
                !string.IsNullOrWhiteSpace(txtCustName.Text) &&
                !string.IsNullOrWhiteSpace(txtCustEmail.Text))
            {
                var c = new Customer { CustomerID = id, Name = txtCustName.Text, Email = txtCustEmail.Text };
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
                !string.IsNullOrWhiteSpace(txtCustName.Text) &&
                !string.IsNullOrWhiteSpace(txtCustEmail.Text))
            {
                var c = new Customer { CustomerID = id, Name = txtCustName.Text, Email = txtCustEmail.Text };
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
                txtCustName.Text = c.Name;
                txtCustEmail.Text = c.Email;
            }
        }

        private void ClearCustomerInput()
        {
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtCustEmail.Text = "";
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
                dpOrderDate.SelectedDate.HasValue)
            {
                // Kiểm tra customer tồn tại
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
                dpOrderDate.SelectedDate.HasValue)
            {
                // Kiểm tra customer tồn tại
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
                dpOrderDate.SelectedDate = o.OrderDate;
            }
        }

        private void ClearOrderInput()
        {
            txtOrderID.Text = "";
            txtOrderCustID.Text = "";
            dpOrderDate.SelectedDate = null;
        }
        #endregion
    }
}