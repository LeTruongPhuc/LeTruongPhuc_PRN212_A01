using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _dal = new EmployeeDAL();
        public IEnumerable<Employee> GetAll() => _dal.GetAll();
        public Employee GetById(int id) => _dal.GetById(id);
        public void Add(Employee emp) => _dal.Add(emp);
        public void Update(Employee emp) => _dal.Update(emp);
        public void Delete(int id) => _dal.Delete(id);
        public Employee Login(string username, string password)
        {
            var emp = _dal.GetByUserName(username);
            return (emp != null && emp.Password == password) ? emp : null;
        }
        public IEnumerable<Employee> Search(string keyword) => _dal.Search(keyword);
    }
}