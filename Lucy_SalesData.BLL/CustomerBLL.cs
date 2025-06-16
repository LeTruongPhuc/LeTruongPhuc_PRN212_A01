using System.Collections.Generic;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDAL _dal = new CustomerDAL();
        public IEnumerable<Customer> GetAll() => _dal.GetAll();
        public Customer GetById(int id) => _dal.GetById(id);
        public void Add(Customer c) => _dal.Add(c);
        public void Update(Customer c) => _dal.Update(c);
        public void Delete(int id) => _dal.Delete(id);
        public IEnumerable<Customer> Search(string keyword) => _dal.Search(keyword);
    }
}