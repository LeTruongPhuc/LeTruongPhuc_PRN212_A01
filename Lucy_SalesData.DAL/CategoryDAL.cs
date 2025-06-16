using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class CategoryDAL
    {
        private readonly List<Category> _categories = DataContext.Instance.Categories;

        public IEnumerable<Category> GetAll() => _categories;
        public Category GetById(int id) => _categories.FirstOrDefault(c => c.CategoryID == id);
        public void Add(Category c)
        {
            c.CategoryID = _categories.Count > 0 ? _categories.Max(cc => cc.CategoryID) + 1 : 1;
            _categories.Add(c);
        }
        public void Update(Category c)
        {
            var cat = GetById(c.CategoryID);
            if (cat != null)
            {
                cat.CategoryName = c.CategoryName;
                cat.Description = c.Description;
            }
        }
        public void Delete(int id)
        {
            var cat = GetById(id);
            if (cat != null) _categories.Remove(cat);
        }
        public IEnumerable<Category> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return _categories.Where(c =>
                c.CategoryName.ToLower().Contains(keyword) ||
                c.Description.ToLower().Contains(keyword));
        }
    }
}