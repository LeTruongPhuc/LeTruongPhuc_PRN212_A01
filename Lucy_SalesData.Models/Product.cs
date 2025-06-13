namespace Lucy_SalesData.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}