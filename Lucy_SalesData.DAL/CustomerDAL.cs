using System.Collections.Generic;
using System.Linq;
using Lucy_SalesData.Models;

namespace Lucy_SalesData.DAL
{
    public class CustomerDAL
    {
        private readonly List<Customer> _customers = DataContext.Instance.Customers;

        public IEnumerable<Customer> GetAll() => _customers;
        public Customer GetById(int id) => _customers.FirstOrDefault(c => c.CustomerID == id);
        public void Add(Customer cus)
        {
            cus.CustomerID = _customers.Count > 0 ? _customers.Max(c => c.CustomerID) + 1 : 1;
            _customers.Add(cus);
        }
        public void Update(Customer cus)
        {
            var c = GetById(cus.CustomerID);
            if (c != null)
            {
                c.CompanyName = cus.CompanyName;
                c.ContactName = cus.ContactName;
                c.ContactTitle = cus.ContactTitle;
                c.Address = cus.Address;
                c.Phone = cus.Phone;
            }
        }
        public void Delete(int id)
        {
            var cus = GetById(id);
            if (cus != null) _customers.Remove(cus);
        }
        public IEnumerable<Customer> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return _customers.Where(c =>
                c.CompanyName.ToLower().Contains(keyword) ||
                c.ContactName.ToLower().Contains(keyword) ||
                c.Phone.ToLower().Contains(keyword));
        }
    }
}