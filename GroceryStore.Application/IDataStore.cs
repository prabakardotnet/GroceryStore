using GroceryStore.Application.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStore.Application
{
    public interface IDataStore
    {
        IList<Customer> Customers { get; }
    }
}
