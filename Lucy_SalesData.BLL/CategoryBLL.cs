using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class CategoryBLL
    {
        private CategoryDAL dal = new CategoryDAL();

        public List<Category> GetAll() => dal.GetAll();
        public Category GetById(int id) => dal.GetById(id);
        public void Add(Category c) => dal.Add(c);
        public void Update(Category c) => dal.Update(c);
        public void Delete(int id) => dal.Delete(id);
        public List<Category> Search(string keyword) => dal.Search(keyword);
    }
}