using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C2C.UI.Controllers
{
    public class StoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
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