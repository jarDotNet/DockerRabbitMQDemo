using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Enumerations;
using OrderApi.Infrastructure.Data.Repository.v1;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.v1.Query
{
    public class GetPaidOrderQueryHandler : IRequestHandler<GetPaidOrderQuery, IEnumerable<Order>>
    {
        private readonly IRepository<Order> _repository;

        public GetPaidOrderQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> Handle(GetPaidOrderQuery request, CancellationToken cancellationToken)
        {
            return await _repository
                .GetAll()
                .Where(order => order.OrderState == eOrderState.Paid)
                .ToListAsync(cancellationToken);
        }
    }
}