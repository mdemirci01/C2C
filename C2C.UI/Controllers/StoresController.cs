using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using C2C.Models;
using C2C.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace C2C.UI.Controllers
{
    public class StoresController : Controller
    {
        
        private readonly ApplicationDbContext context;
        private readonly object _context;
        private readonly IStoreService storeService;
        public StoresController(ApplicationDbContext context, IStoreService storeService)
		{
			this.context = context;
            this.storeService = storeService;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Store store)
        {
            if (ModelState.IsValid)
            {
                await storeService.InsertAsync(store);
            }
            return View(store);
        }

        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                await storeService.UpdateAsync(store);
            }
            return View(store);
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Store store)
        {
            if (ModelState.IsValid)
            {
                await storeService.DeleteAsync(store);
            }
            return View(store);
        }


    }
    }

