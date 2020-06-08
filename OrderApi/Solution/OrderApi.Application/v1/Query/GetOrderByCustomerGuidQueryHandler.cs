using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Infrastructure.Data.Repository.v1;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Application.v1.Query
{
    public class GetOrderByCustomerGuidQueryHandler : IRequestHandler<GetOrderByCustomerGuidQuery, IEnumerable<Order>>
    {
        private readonly IRepository<Order> _repository;

        public GetOrderByCustomerGuidQueryHandler(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrderByCustomerGuidQuery request, CancellationToken cancellationToken)
        {
            return await _repository
                .GetAll()
                .Where(order => order.CustomerGuid == request.CustomerCuid)
                .ToListAsync(cancellationToken);
        }
    }
}