using MediatR;
using OrderApi.Domain.Entities;
using System.Collections.Generic;

namespace OrderApi.Application.v1.Command
{
    public class UpdateOrderCommand : IRequest
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}