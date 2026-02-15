using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;

        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var deliquents = await _context.Delinquents.ToListAsync();
            return View(deliquents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Violation, DelinquentType, Description")] Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var delinquent = await _context.Delinquents.FindAsync(id);
            return View(delinquent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DelinquentID == id);

            if (delinquent == null)
            {
                return NotFound();
            }
            return View("Edit", delinquent);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEdit([Bind("DelinquentID, LastName, FirstName, Violation, DelinquentType, Description")] Delinquent delinquent)
        {
            if (delinquent.DelinquentID == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Delinquents.Update(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Edit", delinquent);
        }


    }
}
