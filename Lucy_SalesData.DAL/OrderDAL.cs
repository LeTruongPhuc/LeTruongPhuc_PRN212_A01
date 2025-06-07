using System.Collections.Generic;
using Lucy_SalesData.Models;
using System.Linq;

namespace Lucy_SalesData.DAL
{
    public class OrderDAL
    {
        private static List<Order> orders = new List<Order>();

        public List<Order> GetAll() => orders.ToList();
        public Order GetById(int id) => orders.FirstOrDefault(o => o.OrderID == id);
        public void Add(Order o) => orders.Add(o);

        public void Update(Order o)
        {
            var idx = orders.FindIndex(x => x.OrderID == o.OrderID);
            if (idx >= 0) orders[idx] = o;
        }

        public void Delete(int id) => orders.RemoveAll(o => o.OrderID == id);

        public List<Order> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return orders.Where(o => o.OrderID.ToString().Contains(keyword) || o.CustomerID.ToString().Contains(keyword)).ToList();
        }
    }
}