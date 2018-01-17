using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SportsStore.Models;
using SportsStore.Services;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        private Cart cart;

        public CartController(IProductRepository repository, Cart cart)
        {
            this.repository = repository;
            this.cart = cart;
        }

        public IActionResult Index()
        {
            return View(cart);
        }

        public IActionResult AddToCart(Guid id)
        {
            var product = repository.Products.Single(p => p.Id == id);

            cart.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(Guid id)
        {
            cart.Remove(id);;

            return RedirectToAction(nameof(Index));
        }
    }
}