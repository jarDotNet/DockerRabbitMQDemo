using AutoMapper;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Enumerations;
using OrderApi.Models.v1;

namespace OrderApi.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>()
                .ForMember(order => order.OrderState, opt => opt.MapFrom(src => eOrderState.Pending));
        }
    }
}