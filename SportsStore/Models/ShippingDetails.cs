using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class ShippingDetails
    {
        [BindNever]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Shipping Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a Country")]
        public string Country { get; set; }

        public bool Gift { get; set; }
    }
}
