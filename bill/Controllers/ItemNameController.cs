using bill.Dynamic;
using bill.Models;
using bill.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bill.Controllers
{
    public class ItemNameController : Controller
    {
        private readonly BillPrintDbContext _context;

        public ItemNameController(BillPrintDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var itemNames = _context.ItemNames.ToList();
            return View(itemNames);
        }

        public IActionResult Create()
        {
            var model = new ItemNameViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemNameViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var itemName = new ItemNameModel
                    {
                        Name = model.Name,
                        CreatedDate = model.CreatedDate,
                    };
                    _context.ItemNames.Add(itemName);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while creating the item name: {ex.Message}");
                return StatusCode(500); // Internal Server Error
            }
        }
    }
}
