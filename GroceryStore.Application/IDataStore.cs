using GroceryStore.Application.Customers;
using System.Collections.Generic;

namespace GroceryStore.Application
{
    public interface IDataStore
    {
        IList<Customer> Customers { get; set; }
    }
}
