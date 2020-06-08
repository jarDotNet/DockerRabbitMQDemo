using CustomerApi.Domain.Entities;
using MediatR;

namespace CustomerApi.Application.v1.Command
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}