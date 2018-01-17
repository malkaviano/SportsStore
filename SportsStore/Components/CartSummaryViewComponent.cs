using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Services;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cart)
        {
            this.cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CartSummary { Show = cart.Total > 0, Items = cart.Items.Sum(p => p.Quantity), Total = cart.Total });
        }
    }

    public class CartSummary
    {
        public bool Show { get; set; }
        public int Items { get; set; }
        public decimal Total { get; set; }
    }
}
