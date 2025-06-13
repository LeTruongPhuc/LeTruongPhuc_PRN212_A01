using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class OrderDetailDAL
    {
        private static List<OrderDetail> orderDetails = new List<OrderDetail>();

        public List<OrderDetail> GetAll() => orderDetails.ToList();
        public List<OrderDetail> GetByOrderId(int orderId) => orderDetails.Where(od => od.OrderID == orderId).ToList();
        public void Add(OrderDetail od) => orderDetails.Add(od);

        public void Update(OrderDetail od)
        {
            var idx = orderDetails.FindIndex(x => x.OrderID == od.OrderID && x.ProductID == od.ProductID);
            if (idx >= 0) orderDetails[idx] = od;
        }

        public void Delete(int orderId, int productId) => orderDetails.RemoveAll(od => od.OrderID == orderId && od.ProductID == productId);

        public List<OrderDetail> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return orderDetails.Where(od =>
                od.OrderID.ToString().Contains(keyword) ||
                od.ProductID.ToString().Contains(keyword)
            ).ToList();
        }
    }
}