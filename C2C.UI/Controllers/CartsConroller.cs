using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C2C.UI.Controllers
{
    public class CartsConroller : Controller
    {

        private readonly ApplicationDbContext context;
        public CartsConroller(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/

        public async Task<IActionResult> Index()
        {
            return View(await context.Stores.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await context.Carts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }
    }
}
