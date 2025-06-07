using System.Collections.Generic;
using Lucy_SalesData.Models;
using System.Linq;

namespace Lucy_SalesData.DAL
{
    public class CustomerDAL
    {
        private static List<Customer> customers = new List<Customer>();

        public List<Customer> GetAll() => customers.ToList();
        public Customer GetById(int id) => customers.FirstOrDefault(c => c.CustomerID == id);
        public void Add(Customer c) => customers.Add(c);

        public void Update(Customer c)
        {
            var idx = customers.FindIndex(x => x.CustomerID == c.CustomerID);
            if (idx >= 0) customers[idx] = c;
        }

        public void Delete(int id) => customers.RemoveAll(c => c.CustomerID == id);

        public List<Customer> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();
            keyword = keyword.ToLower();
            return customers.Where(c => c.Name.ToLower().Contains(keyword) || c.Email.ToLower().Contains(keyword)).ToList();
        }
    }
}