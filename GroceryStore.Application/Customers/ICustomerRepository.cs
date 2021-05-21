using System.Collections.Generic;

namespace GroceryStore.Application.Customers
{
    public interface ICustomerService
    {
        IEnumerable<Customer> List();
        Customer Get(int id);
        int Add(Customer customer);
        void Update(Customer customer);
    }
}
