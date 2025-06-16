using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class EmployeeDAL
    {
        private readonly List<Employee> _employees = DataContext.Instance.Employees;

        public IEnumerable<Employee> GetAll() => _employees;
        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.EmployeeID == id);
        public Employee GetByUserName(string username) => _employees.FirstOrDefault(e => e.UserName == username);
        public void Add(Employee emp)
        {
            emp.EmployeeID = _employees.Count > 0 ? _employees.Max(e => e.EmployeeID) + 1 : 1;
            _employees.Add(emp);
        }
        public void Update(Employee emp)
        {
            var e = GetById(emp.EmployeeID);
            if (e != null)
            {
                e.Name = emp.Name;
                e.UserName = emp.UserName;
                e.Password = emp.Password;
                e.JobTitle = emp.JobTitle;
            }
        }
        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null) _employees.Remove(emp);
        }
        public IEnumerable<Employee> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return _employees.Where(e =>
                e.Name.ToLower().Contains(keyword) ||
                e.UserName.ToLower().Contains(keyword) ||
                e.JobTitle.ToLower().Contains(keyword));
        }
    }
}