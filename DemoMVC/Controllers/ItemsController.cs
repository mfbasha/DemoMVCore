using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class ItemsController : Controller
    {
        private MyAppContext _context;

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }
        
        
       public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Index of Items";
            IEnumerable<Item> items = await _context.Items.Include(i=> i.Specs).ToListAsync();
            return View(items);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           return View(item);
        }

        public IActionResult Edit(int id)
        {
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    
    }
}