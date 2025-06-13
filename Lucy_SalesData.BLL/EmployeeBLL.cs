using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class EmployeeBLL
    {
        private EmployeeDAL dal = new EmployeeDAL();

        public List<Employee> GetAll() => dal.GetAll();
        public Employee GetById(int id) => dal.GetById(id);
        public Employee GetByUserName(string username) => dal.GetByUserName(username);
        public void Add(Employee e) => dal.Add(e);
        public void Update(Employee e) => dal.Update(e);
        public void Delete(int id) => dal.Delete(id);
        public List<Employee> Search(string keyword) => dal.Search(keyword);
    }
}