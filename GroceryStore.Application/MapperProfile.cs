using AutoMapper;
using GroceryStore.Application.Customers;

namespace GroceryStore.Application
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
