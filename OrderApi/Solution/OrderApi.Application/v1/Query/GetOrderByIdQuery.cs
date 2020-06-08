using MediatR;
using OrderApi.Domain.Entities;
using System;

namespace OrderApi.Application.v1.Query
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
