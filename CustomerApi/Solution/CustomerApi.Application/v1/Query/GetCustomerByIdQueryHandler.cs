using CustomerApi.Domain.Entities;
using CustomerApi.Infrastructure.Data.Repository.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Application.v1.Query
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository
                .GetAll()
                .FirstOrDefaultAsync(customer => customer.Id == request.Id, cancellationToken);
        }
    }
}