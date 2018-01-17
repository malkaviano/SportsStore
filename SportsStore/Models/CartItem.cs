using System;
using System.Collections.Generic;

namespace SportsStore.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; }

        public CartItem(Product product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}