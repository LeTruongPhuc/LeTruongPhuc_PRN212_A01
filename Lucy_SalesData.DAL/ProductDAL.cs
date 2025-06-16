using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class ProductDAL
    {
        private readonly List<Product> _products = DataContext.Instance.Products;

        public IEnumerable<Product> GetAll() => _products;
        public Product GetById(int id) => _products.FirstOrDefault(p => p.ProductID == id);
        public void Add(Product p)
        {
            p.ProductID = _products.Count > 0 ? _products.Max(pp => pp.ProductID) + 1 : 1;
            _products.Add(p);
        }
        public void Update(Product p)
        {
            var pp = GetById(p.ProductID);
            if (pp != null)
            {
                pp.ProductName = p.ProductName;
                pp.CategoryID = p.CategoryID;
                pp.UnitPrice = p.UnitPrice;
                pp.UnitsInStock = p.UnitsInStock;
            }
        }
        public void Delete(int id)
        {
            var prod = GetById(id);
            if (prod != null) _products.Remove(prod);
        }
        public IEnumerable<Product> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return _products.Where(p =>
                p.ProductName.ToLower().Contains(keyword));
        }
    }
}