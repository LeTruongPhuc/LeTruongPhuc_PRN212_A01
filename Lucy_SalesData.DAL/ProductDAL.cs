using Lucy_SalesData.Models;
using System.Linq;
using System.Collections.Generic;

namespace Lucy_SalesData.DAL
{
    public class ProductDAL
    {
        private static List<Product> products = new List<Product>();

        public List<Product> GetAll() => products.ToList();
        public Product GetById(int id) => products.FirstOrDefault(p => p.ProductID == id);
        public void Add(Product p) => products.Add(p);
        public void Update(Product p)
        {
            var idx = products.FindIndex(x => x.ProductID == p.ProductID);
            if (idx >= 0) products[idx] = p;
        }
        public void Delete(int id) => products.RemoveAll(p => p.ProductID == id);

        public List<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return products.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();
        }
    }
}