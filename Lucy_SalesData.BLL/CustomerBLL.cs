using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class CustomerBLL
    {
        private CustomerDAL dal = new CustomerDAL();

        public List<Customer> GetAll() => dal.GetAll();
        public Customer GetById(int id) => dal.GetById(id);
        public void Add(Customer c) => dal.Add(c);
        public void Update(Customer c) => dal.Update(c);
        public void Delete(int id) => dal.Delete(id);
        public List<Customer> Search(string keyword) => dal.Search(keyword);
    }
}