using GroceryStore.Application.Customers;
using System.Collections.Generic;

namespace GroceryStore.Application
{
    public class DataStore : IDataStore
    {
        public IList<Customer> Customers { get; set; }

        public DataStore()
        {
            Customers = new List<Customer>();
        }
    }
}
