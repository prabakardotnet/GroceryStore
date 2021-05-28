using GroceryStore.Application;
using GroceryStore.Application.Customers;
using System.Linq;
using Xunit;

namespace GroceryStore.Tests.Customers
{
    public class CustomerRepositoryTests
    {
        private IDataStore _dataStore;
        private ICustomerRepository _customerRepository;
        public CustomerRepositoryTests()
        {
            _dataStore = new DataStore();
            _customerRepository = new CustomerRepository(_dataStore);
        }
        [Fact]
        public void CanListAllCustomers()
        {
            //Arrange 
            int numberOfCustomers = 3;
            for (int i = 0; i < numberOfCustomers; i++)
            {
                _dataStore.Customers.Add(new Application.Customers.Customer { Id = i, Name = $"RandomName{i}" });
            }

            //Act
            var customersList = _customerRepository.List();

            //Assert 
            Assert.Equal(numberOfCustomers, customersList.Count());
        }

        [Fact]
        public void GivenExistingCustomerIdRetrievesTheRightCustomer()
        {
            //Arrange 
            int numberOfCustomers = 1;
            int lastCustomerId = 0;
            for (int i = 0; i < numberOfCustomers; i++)
            {
                _dataStore.Customers.Add(new Customer { Id = i, Name = $"RandomName{i}" });
                lastCustomerId = i;
            }
            
            //Act
            var customer = _customerRepository.Get(lastCustomerId);

            //Assert 
            Assert.Equal(lastCustomerId,customer.Id);
        }

        [Fact]
        public void CanAddCustomer()
        {
            //Arrange 
            int numberOfCustomers = 1;
            int lastCustomerId = 0;
            for (int i = 0; i < numberOfCustomers; i++)
            {
                _dataStore.Customers.Add(new Customer { Id = i, Name = $"RandomName{i}" });
                lastCustomerId = i;
            }

            //Act
            var customerExists = _customerRepository.Exists(lastCustomerId);

            //Assert 
            Assert.True(customerExists);
        }

        [Fact]
        public void CanUpdateCustomer()
        {
            //Arrange 
            int numberOfCustomers = 1;
            int lastCustomerId = 0;
            for (int i = 0; i < numberOfCustomers; i++)
            {
                _dataStore.Customers.Add(new Customer { Id = i, Name = $"RandomName{i}" });
                lastCustomerId = i;
            }

            //Act
            string updatedName = "updatedName";
            _customerRepository.Update(new Customer { Id = lastCustomerId, Name = updatedName });
            Customer customer = _customerRepository.Get(lastCustomerId);
            
            //Assert 
            Assert.Equal(customer.Name,updatedName);
        }
    }
}
