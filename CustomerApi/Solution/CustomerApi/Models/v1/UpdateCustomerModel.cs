using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models.v1
{
    [Serializable]
    public class UpdateCustomerModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Age { get; set; }
    }
}