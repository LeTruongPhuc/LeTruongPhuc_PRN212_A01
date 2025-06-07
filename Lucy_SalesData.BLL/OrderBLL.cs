using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class OrderBLL
    {
        private OrderDAL dal = new OrderDAL();

        public List<Order> GetAll() => dal.GetAll();
        public Order GetById(int id) => dal.GetById(id);
        public void Add(Order o) => dal.Add(o);
        public void Update(Order o) => dal.Update(o);
        public void Delete(int id) => dal.Delete(id);
        public List<Order> Search(string keyword) => dal.Search(keyword);
    }
}