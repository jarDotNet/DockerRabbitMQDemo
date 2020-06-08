using CustomerApi.Domain.Entities;
using MediatR;

namespace CustomerApi.Application.v1.Command
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}