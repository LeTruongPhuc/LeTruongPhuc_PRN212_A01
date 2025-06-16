using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class OrderDAL
    {
        private readonly List<Order> _orders = DataContext.Instance.Orders;

        public IEnumerable<Order> GetAll() => _orders;
        public Order GetById(int id) => _orders.FirstOrDefault(o => o.OrderID == id);
        public void Add(Order o)
        {
            o.OrderID = _orders.Count > 0 ? _orders.Max(oo => oo.OrderID) + 1 : 1;
            _orders.Add(o);
        }
        public void Update(Order o)
        {
            var oo = GetById(o.OrderID);
            if (oo != null)
            {
                oo.CustomerID = o.CustomerID;
                oo.EmployeeID = o.EmployeeID;
                oo.OrderDate = o.OrderDate;
            }
        }
        public void Delete(int id)
        {
            var ord = GetById(id);
            if (ord != null) _orders.Remove(ord);
        }
        public IEnumerable<Order> SearchByCustomer(int customerId)
        {
            return _orders.Where(o => o.CustomerID == customerId);
        }
    }
}