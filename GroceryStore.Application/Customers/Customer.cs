namespace GroceryStore.Application.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer()
        {
            Id = 0;
            Name = "";
        }
    }
}
