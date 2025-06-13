using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class EmployeeDAL
    {
        private static List<Employee> employees = new List<Employee>();

        public List<Employee> GetAll() => employees.ToList();
        public Employee GetById(int id) => employees.FirstOrDefault(e => e.EmployeeID == id);
        public Employee GetByUserName(string username) => employees.FirstOrDefault(e => e.UserName == username);
        public void Add(Employee e) => employees.Add(e);

        public void Update(Employee e)
        {
            var idx = employees.FindIndex(x => x.EmployeeID == e.EmployeeID);
            if (idx >= 0) employees[idx] = e;
        }

        public void Delete(int id) => employees.RemoveAll(e => e.EmployeeID == id);

        public List<Employee> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return employees.Where(e =>
                (e.Name != null && e.Name.ToLower().Contains(keyword)) ||
                (e.UserName != null && e.UserName.ToLower().Contains(keyword)) ||
                (e.JobTitle != null && e.JobTitle.ToLower().Contains(keyword))
            ).ToList();
        }
    }
}