using System.Collections.Generic;

namespace GroceryStore.Application.Customers
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> List();
        CustomerDto Get(int id);
        int Add(CustomerDto customer);
        void Update(CustomerDto customer);
        bool Delete(int id);
        bool Exists(int id);
    }
}
