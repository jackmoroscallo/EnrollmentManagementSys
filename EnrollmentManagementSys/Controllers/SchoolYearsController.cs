using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnrollmentManagementSys.Data;
using EnrollmentManagementSys.Models;

namespace EnrollmentManagementSys.Controllers
{
    public class SchoolYearsController : Controller
    {
        private readonly AppDBContext _context;

        public SchoolYearsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: SchoolYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolYears.ToListAsync());
        }

        // GET: SchoolYears/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolYear = await _context.SchoolYears
                .FirstOrDefaultAsync(m => m.SchoolYearID == id);
            if (schoolYear == null)
            {
                return NotFound();
            }

            return View(schoolYear);
        }

        // GET: SchoolYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolYearID,SchoolYearName")] SchoolYear schoolYear)
        {
            if (ModelState.IsValid)
            {
                schoolYear.SchoolYearID = Guid.NewGuid();
                _context.Add(schoolYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolYear);
        }

        // GET: SchoolYears/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolYear = await _context.SchoolYears.FindAsync(id);
            if (schoolYear == null)
            {
                return NotFound();
            }
            return View(schoolYear);
        }

        // POST: SchoolYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SchoolYearID,SchoolYearName")] SchoolYear schoolYear)
        {
            if (id != schoolYear.SchoolYearID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolYearExists(schoolYear.SchoolYearID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schoolYear);
        }

        // GET: SchoolYears/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolYear = await _context.SchoolYears
                .FirstOrDefaultAsync(m => m.SchoolYearID == id);
            if (schoolYear == null)
            {
                return NotFound();
            }

            return View(schoolYear);
        }

        // POST: SchoolYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schoolYear = await _context.SchoolYears.FindAsync(id);
            if (schoolYear != null)
            {
                _context.SchoolYears.Remove(schoolYear);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolYearExists(Guid id)
        {
            return _context.SchoolYears.Any(e => e.SchoolYearID == id);
        }
    }
}
