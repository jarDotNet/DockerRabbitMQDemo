using MediatR;
using OrderApi.Domain.Entities;
using OrderApi.Infrastructure.Data.Repository.v1;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.v1.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IRepository<Order> _repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Order);
        }
    }
}