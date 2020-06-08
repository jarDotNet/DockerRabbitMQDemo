using CustomerApi.Domain.Entities;

namespace CustomerApi.Infrastructure.Messaging.Send.Sender.v1
{
    public interface ICustomerUpdateSender
    {
        void SendCustomer(Customer customer);
    }
}