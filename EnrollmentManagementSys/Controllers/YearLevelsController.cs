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
    public class YearLevelsController : Controller
    {
        private readonly AppDBContext _context;

        public YearLevelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: YearLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.YearLevels.ToListAsync());
        }

        // GET: YearLevels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yearLevel = await _context.YearLevels
                .FirstOrDefaultAsync(m => m.YearLevelID == id);
            if (yearLevel == null)
            {
                return NotFound();
            }

            return View(yearLevel);
        }

        // GET: YearLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YearLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YearLevelID,YearLevelNum")] YearLevel yearLevel)
        {
            if (ModelState.IsValid)
            {
                yearLevel.YearLevelID = Guid.NewGuid();
                _context.Add(yearLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yearLevel);
        }

        // GET: YearLevels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yearLevel = await _context.YearLevels.FindAsync(id);
            if (yearLevel == null)
            {
                return NotFound();
            }
            return View(yearLevel);
        }

        // POST: YearLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("YearLevelID,YearLevelNum")] YearLevel yearLevel)
        {
            if (id != yearLevel.YearLevelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yearLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YearLevelExists(yearLevel.YearLevelID))
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
            return View(yearLevel);
        }

        // GET: YearLevels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yearLevel = await _context.YearLevels
                .FirstOrDefaultAsync(m => m.YearLevelID == id);
            if (yearLevel == null)
            {
                return NotFound();
            }

            return View(yearLevel);
        }

        // POST: YearLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yearLevel = await _context.YearLevels.FindAsync(id);
            if (yearLevel != null)
            {
                _context.YearLevels.Remove(yearLevel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YearLevelExists(Guid id)
        {
            return _context.YearLevels.Any(e => e.YearLevelID == id);
        }
    }
}
