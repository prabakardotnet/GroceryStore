using System.Collections.Generic;
using System.Linq;

namespace GroceryStore.Application.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDataStore _dataStore;
        public CustomerRepository(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public int Add(Customer customer)
        {
            int customerId = _dataStore.Customers.Any() ? _dataStore.Customers.Max(c => c.Id) : 0;
            customer.Id = ++customerId;
            _dataStore.Customers.Add(customer);
            return customerId;
        }

        public Customer Get(int id)
        {
            return _dataStore.Customers.First(c => c.Id == id);
        }

        public IEnumerable<Customer> List()
        {
            return _dataStore.Customers;
        }

        public void Update(Customer customer)
        {
            Customer existingCustomer = Get(customer.Id);
            existingCustomer.Name = customer.Name;
        }

        public bool Exists(int id)
        {
            return _dataStore.Customers.Any(c => c.Id == id);
        }

        public bool Delete(int id)
        {
            if (Exists(id))
            {
                Customer customer = Get(id);
                _dataStore.Customers.Remove(customer);
                return true;
            }
            return false;
        }
    }
}
