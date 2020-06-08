using AutoMapper;
using CustomerApi.Domain.Entities;
using CustomerApi.Models.v1;

namespace CustomerApi.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>().ForMember(customer => customer.Id, opt => opt.Ignore());

            CreateMap<UpdateCustomerModel, Customer>();
}
    }
}
