using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using C2C.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C2C.UI.Controllers
{
    public class StoresController : Controller
    {
		private readonly ApplicationDbContext context;
		public StoresController(ApplicationDbContext context)
		{
			this.context = context;
		}

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

            var store = await context.Stores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }
    }

}