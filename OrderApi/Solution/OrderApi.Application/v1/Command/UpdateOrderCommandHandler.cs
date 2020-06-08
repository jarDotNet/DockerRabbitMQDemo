using MediatR;
using OrderApi.Domain.Entities;
using OrderApi.Infrastructure.Data.Repository.v1;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.v1.Command
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<Order> _repository;

        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateRangeAsync(request.Orders);

            return Unit.Value;
        }
    }
}