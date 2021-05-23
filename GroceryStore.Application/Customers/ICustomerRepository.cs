using System.Collections.Generic;

namespace GroceryStore.Application.Customers
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> List();
        Customer Get(int id);
        int Add(Customer customer);
        void Update(Customer customer);
        bool Exists(int id);
        bool Delete(int id);
        
    }
}
