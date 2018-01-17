using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModel;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize { get; set; } = 3;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult List(string category = null, int page = 1)
        {
            var result = repository.Products
                                    .Where(p => string.IsNullOrWhiteSpace(category) || 
                                                p.Category.ToLower() == category.ToLower())
                                    .OrderBy(p => p.Id);

            ViewBag.PagingInfo = new PagingInfo { Current = page, PerPage = PageSize, Total = result.Count() };
            ViewBag.Category = category;

            return View(
                result.Skip((page - 1) * PageSize)
                        .Take(PageSize)
            );
        }
    }
}