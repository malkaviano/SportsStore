using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public ShippingDetails Details { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal Total { get; set; }

        public Order(ShippingDetails details, Cart cart)
        {
            Details = details;
            Items = cart.Items.ToList();
            Total = cart.Total;
        }
    }
}
