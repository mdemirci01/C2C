using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using C2C.Service;
using Microsoft.AspNetCore.Mvc;

namespace C2C.UI.Controllers
{
    public class StoresController : Controller
    {
		private readonly ApplicationDbContext context;
		public StoresController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
        {
			var stores = context.Stores.ToList();
			return View(stores);
        }

		public IActionResult Create()
		{
			return View();
		}

		public IActionResult Edit()
		{
			return View();
		}

		public IActionResult Delete()
		{
			return View();
		}

		public IActionResult Detalis()
		{
			return View();
		}
    }

}