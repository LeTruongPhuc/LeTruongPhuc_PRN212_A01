using System.Collections.Generic;
using Lucy_SalesData.DAL;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.BLL
{
    public class OrderDetailBLL
    {
        private OrderDetailDAL dal = new OrderDetailDAL();

        public List<OrderDetail> GetAll() => dal.GetAll();
        public List<OrderDetail> GetByOrderId(int orderId) => dal.GetByOrderId(orderId);
        public void Add(OrderDetail od) => dal.Add(od);
        public void Update(OrderDetail od) => dal.Update(od);
        public void Delete(int orderId, int productId) => dal.Delete(orderId, productId);
        public List<OrderDetail> Search(string keyword) => dal.Search(keyword);
    }
}