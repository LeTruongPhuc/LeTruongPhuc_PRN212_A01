using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class OrderDetailDAL
    {
        private readonly List<OrderDetail> _orderDetails = DataContext.Instance.OrderDetails;

        public IEnumerable<OrderDetail> GetAll() => _orderDetails;
        public IEnumerable<OrderDetail> GetByOrderId(int orderId) => _orderDetails.Where(od => od.OrderID == orderId);
        public void Add(OrderDetail od) => _orderDetails.Add(od);
        public void Update(OrderDetail od)
        {
            var o = _orderDetails.FirstOrDefault(x => x.OrderID == od.OrderID && x.ProductID == od.ProductID);
            if (o != null)
            {
                o.UnitPrice = od.UnitPrice;
                o.Quantity = od.Quantity;
                o.Discount = od.Discount;
            }
        }
        public void Delete(int orderId, int productId)
        {
            var od = _orderDetails.FirstOrDefault(x => x.OrderID == orderId && x.ProductID == productId);
            if (od != null) _orderDetails.Remove(od);
        }
    }
}