using MediatR;
using OrderApi.Application.v1.Command;
using OrderApi.Application.v1.Models;
using OrderApi.Application.v1.Query;
using System;
using System.Diagnostics;
using System.Linq;

namespace OrderApi.Application.v1.Services
{
    public class CustomerNameUpdateService : ICustomerNameUpdateService
    {
        private readonly IMediator _mediator;

        public CustomerNameUpdateService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try
            {
                var ordersOfCustomer = (await _mediator.Send(new GetOrderByCustomerGuidQuery
                {
                    CustomerCuid = updateCustomerFullNameModel.Id
                })).ToList();

                if (ordersOfCustomer.Count != 0)
                {
                    var updatedCustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}";

                    ordersOfCustomer.ForEach(order => order.CustomerFullName = updatedCustomerFullName);
                }

                await _mediator.Send(new UpdateOrderCommand
                {
                    Orders = ordersOfCustomer
                });
            }
            catch (Exception ex)
            {
               // log an error message here

               Debug.WriteLine(ex.Message);
            }
        }
    }
}