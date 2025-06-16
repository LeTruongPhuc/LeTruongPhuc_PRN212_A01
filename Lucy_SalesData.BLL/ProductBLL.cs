using System.Collections.Generic;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class ProductBLL
    {
        private readonly ProductDAL _dal = new ProductDAL();
        public IEnumerable<Product> GetAll() => _dal.GetAll();
        public Product GetById(int id) => _dal.GetById(id);
        public void Add(Product p) => _dal.Add(p);
        public void Update(Product p) => _dal.Update(p);
        public void Delete(int id) => _dal.Delete(id);
        public IEnumerable<Product> Search(string keyword) => _dal.Search(keyword);
    }
}