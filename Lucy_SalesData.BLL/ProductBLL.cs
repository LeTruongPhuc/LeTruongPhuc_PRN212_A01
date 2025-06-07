using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class ProductBLL
    {
        private ProductDAL dal = new ProductDAL();

        public List<Product> GetAll() => dal.GetAll();
        public Product GetById(int id) => dal.GetById(id);
        public void Add(Product p) => dal.Add(p);
        public void Update(Product p) => dal.Update(p);
        public void Delete(int id) => dal.Delete(id);
        public List<Product> Search(string keyword) => dal.Search(keyword);
    }
}