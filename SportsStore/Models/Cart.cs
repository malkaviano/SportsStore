using Microsoft.AspNetCore.Http;
using SportsStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Cart
    {
        private ISession storage;

        private Dictionary<Guid, CartItem> cart;

        public virtual IEnumerable<CartItem> Items { get => cart.Values; }

        public virtual decimal Total { get => Items.Sum(ci => ci.Product.Price * ci.Quantity); }

        public Cart(ISession storage) : this(storage, new CartItem[0])
        {
        }

        public Cart(ISession storage, CartItem[] items)
        {
            this.storage = storage;
            cart = items.ToDictionary(ci => ci.Product.Id);
            Save();
        }

        public virtual void Add(Product product)
        {
            if (cart.ContainsKey(product.Id))
            {
                cart[product.Id].Quantity++;
            }
            else
            {
                cart[product.Id] = new CartItem(product);
            }

            Save();
        }

        public virtual void Clear()
        {
            cart.Clear();

            storage.Remove(nameof(Cart));
        }

        public virtual void Remove(Guid id)
        {
            cart.Remove(id);

            Save();
        }

        public void ModifyQuantity(Guid id, int qty)
        {
            if (qty <= 0)
            {
                cart.Remove(id);
            }
            else if(cart.ContainsKey(id))
            {
                cart[id].Quantity = qty;
            }

            Save();
        }

        private void Save()
        {
            storage.SaveCart(this);
        }
    }
}
