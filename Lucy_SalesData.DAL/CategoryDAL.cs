using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class CategoryDAL
    {
        private static List<Category> categories = new List<Category>();

        public List<Category> GetAll() => categories.ToList();
        public Category GetById(int id) => categories.FirstOrDefault(c => c.CategoryID == id);
        public void Add(Category c) => categories.Add(c);

        public void Update(Category c)
        {
            var idx = categories.FindIndex(x => x.CategoryID == c.CategoryID);
            if (idx >= 0) categories[idx] = c;
        }

        public void Delete(int id) => categories.RemoveAll(c => c.CategoryID == id);

        public List<Category> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return categories.Where(c =>
                (c.CategoryName != null && c.CategoryName.ToLower().Contains(keyword)) ||
                (c.Description != null && c.Description.ToLower().Contains(keyword))
            ).ToList();
        }
    }
}