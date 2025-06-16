using System.Collections.Generic;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class DataContext
    {
        private static DataContext? _instance;
        public static DataContext Instance => _instance ??= new DataContext();

        public List<Employee> Employees { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Category> Categories { get; set; }

        private DataContext()
        {
            Employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Admin", UserName = "admin", Password = "123", JobTitle = "ad" }
            };
            Customers = new List<Customer>();
            Products = new List<Product>();
            Orders = new List<Order>();
            OrderDetails = new List<OrderDetail>();
            Categories = new List<Category>();
        }
    }
}