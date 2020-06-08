using OrderApi.Application.v1.Models;

namespace OrderApi.Application.v1.Services
{
    public interface ICustomerNameUpdateService
    {
        void UpdateCustomerNameInOrders(UpdateCustomerFullNameModel updateCustomerFullNameModel);
    }
}