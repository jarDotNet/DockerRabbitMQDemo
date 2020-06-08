using MediatR;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OrderApi.Application.v1.Query
{
    public class GetOrderByCustomerGuidQuery : IRequest<IEnumerable<Order>>
    {
        public Guid CustomerCuid { get; set; }
    }
}