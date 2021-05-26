using GroceryStore.Application.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStore.Application
{
    public interface IDataStore
    {
        void SaveChanges();
        IList<Customer> Customers { get; }
    }
}
