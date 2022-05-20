using AutoMapper;
using OrderApp.Dto;
using OrderApp.Model;

namespace OrderApp.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Model.Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}