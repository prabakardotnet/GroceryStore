using GroceryStore.Application.Customers;
using System.Collections.Generic;

namespace GroceryStore.Application
{
    public class Database
    {
        public IList<Customer> Customers { get; set; }
        public Database()
        {
            Customers = new List<Customer>();
        }
    }
}
