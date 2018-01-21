using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ShippingController : Controller
    {
        private IOrderRepository repository;

        public ShippingController(IOrderRepository repoService)
        {
            repository = repoService;
        }

        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(Guid id)
        {
            var order = repository.Orders.Single(o => o.Id == id);

            order.Shipped = true;
            repository.SaveOrder(order);

            return RedirectToAction(nameof(List));
        }
    }
}