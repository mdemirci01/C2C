using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C2C.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
    }
}
