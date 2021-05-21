using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GroceryStore.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> List()
        {
            return _customerRepository.List();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
