using OrderApi.Domain.Enumerations;
using System;

namespace OrderApi.Domain.Entities
{
    [Serializable]
    public class Order
    {
        public Guid Id { get; set; }
        public eOrderState OrderState { get; set; }
        public Guid CustomerGuid { get; set; }
        public string CustomerFullName { get; set; }
    }
}
