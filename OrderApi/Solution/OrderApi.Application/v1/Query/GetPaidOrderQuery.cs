using MediatR;
using OrderApi.Domain.Entities;
using System.Collections.Generic;

namespace OrderApi.Application.v1.Query
{
    public class GetPaidOrderQuery : IRequest<IEnumerable<Order>>
    {
    }
}