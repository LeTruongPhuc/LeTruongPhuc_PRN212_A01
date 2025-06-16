using System.Collections.Generic;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _dal = new CategoryDAL();
        public IEnumerable<Category> GetAll() => _dal.GetAll();
        public Category GetById(int id) => _dal.GetById(id);
        public void Add(Category c) => _dal.Add(c);
        public void Update(Category c) => _dal.Update(c);
        public void Delete(int id) => _dal.Delete(id);
        public IEnumerable<Category> Search(string keyword) => _dal.Search(keyword);
    }
}