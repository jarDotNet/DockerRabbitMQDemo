using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Infrastructure.Data.Repository.v1;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.v1.Query
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderByIdQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository
                .GetAll()
                .FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);
        }
    }
}