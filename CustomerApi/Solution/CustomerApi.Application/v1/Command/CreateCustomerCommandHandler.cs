using CustomerApi.Domain.Entities;
using CustomerApi.Infrastructure.Data.Repository.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Application.v1.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Customer);
        }
    }
}