using bill.Dynamic;
using bill.Models;
using bill.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bill.Controllers
{
    public class CalculateBillController : Controller
    {
        private readonly BillPrintDbContext _context;

        public CalculateBillController(BillPrintDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CalculateBill()
        {
            var bills = await _context.CalculateBills.Include(b => b.ItemName).ToListAsync();
            return View("CalculateBillView", bills); // Assuming "CalculateBillView" is the new name of your view file
        }

        public IActionResult CreateBill()
        {
            ViewData["ItemNames"] = new SelectList(_context.ItemNames, "Id", "Name");
            var model = new CalculateBillViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBill(CalculateBillViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var calculateBill = new CalculateBillModel
                    {
                        Name = model.Name,
                        Address = model.Address,
                        Pan_No = model.Pan_No,
                        Price = model.Price,
                        ItemNameId = model.ItemNameId,
                        TotalPrice = model.Price, // Here you might want to include additional calculations
                        BillNo = model.BillNo,
                        CreatedDate = model.CreatedDate
                    };
                    _context.CalculateBills.Add(calculateBill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewData["ItemName"] = new SelectList(_context.ItemNames, "Id", "Name", model.ItemNameId);
                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while creating the bill: {ex.Message}");
                return StatusCode(500); // Internal Server Error
            }
        }
    }
}
