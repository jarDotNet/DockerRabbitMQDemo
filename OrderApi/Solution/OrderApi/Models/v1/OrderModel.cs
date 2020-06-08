using System;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.v1
{
    [Serializable]
    public class OrderModel
    {
        [Required]
        public Guid CustomerGuid { get; set; }

        [Required]
        public string CustomerFullName { get; set; }
    }
}