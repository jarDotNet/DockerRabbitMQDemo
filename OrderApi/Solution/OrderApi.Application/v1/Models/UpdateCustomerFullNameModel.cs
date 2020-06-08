using System;

namespace OrderApi.Application.v1.Models
{
    [Serializable]
    public class UpdateCustomerFullNameModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}