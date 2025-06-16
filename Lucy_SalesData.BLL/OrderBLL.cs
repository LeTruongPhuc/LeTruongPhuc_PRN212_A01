using System.Collections.Generic;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL _dal = new OrderDAL();
        public IEnumerable<Order> GetAll() => _dal.GetAll();
        public Order GetById(int id) => _dal.GetById(id);
        public void Add(Order o) => _dal.Add(o);
        public void Update(Order o) => _dal.Update(o);
        public void Delete(int id) => _dal.Delete(id);
        public IEnumerable<Order> SearchByCustomer(int customerId) => _dal.SearchByCustomer(customerId);
    }
}