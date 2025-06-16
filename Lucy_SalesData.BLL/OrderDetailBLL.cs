using System.Collections.Generic;
using Lucy_SalesData.Models;
using Lucy_SalesData.DAL;

namespace Lucy_SalesData.BLL
{
    public class OrderDetailBLL
    {
        private readonly OrderDetailDAL _dal = new OrderDetailDAL();
        public IEnumerable<OrderDetail> GetAll() => _dal.GetAll();
        public IEnumerable<OrderDetail> GetByOrderId(int orderId) => _dal.GetByOrderId(orderId);
        public void Add(OrderDetail od) => _dal.Add(od);
        public void Update(OrderDetail od) => _dal.Update(od);
        public void Delete(int orderId, int productId) => _dal.Delete(orderId, productId);
    }
}