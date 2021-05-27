using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Application.Customers
{
    public record CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public CustomerDto()
        {
            Name = string.Empty;
        }
    }
}
