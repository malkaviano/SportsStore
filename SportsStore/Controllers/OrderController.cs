using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private Cart cart;

        private IOrderRepository repository;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            this.cart = cart;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public IActionResult Checkout(ShippingDetails details)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("CartEmpty", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                var order = new Order(details, cart);

                repository.SaveOrder(order);

                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(details);
            }
        }

        public IActionResult Completed()
        {
            cart.Clear();

            return View();
        }
    }
}