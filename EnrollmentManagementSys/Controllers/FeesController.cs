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
    public class FeesController : Controller
    {
        private readonly AppDBContext _context;

        public FeesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Fees
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Fees.Include(f => f.FeeType).Include(f => f.Term).Include(f => f.YearLevel).Include(f => f.StudentCourse).Include(f => f.SchoolYear);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .Include(f => f.FeeType)
                .Include(f => f.StudentCourse)
                .Include(f => f.Term)
                .Include(f => f.YearLevel)
                .Include(f => f.SchoolYear)
                .FirstOrDefaultAsync(m => m.FeeID == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
            ViewData["FeeTypeID"] = new SelectList(_context.FeeTypes, "FeeTypeID", "FeeTypeName");
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName");
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum");
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName");
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeID,Description,Amount,FeeTypeID,StudentCourseID,YearLevelID,SchoolYearID,TermID")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                fee.FeeID = Guid.NewGuid();
                _context.Add(fee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FeeTypeID"] = new SelectList(_context.FeeTypes, "FeeTypeID", "FeeTypeID", fee.FeeTypeID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermID", fee.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelID", fee.YearLevelID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", fee.SchoolYearID);
            return View(fee);
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }
            ViewData["FeeTypeID"] = new SelectList(_context.FeeTypes, "FeeTypeID", "FeeTypeName", fee.FeeTypeID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName", fee.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum", fee.YearLevelID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", fee.SchoolYearID);
            return View(fee);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FeeID,Description,Amount,FeeTypeID,StudentCourseID,YearLevelID,SchoolYearID,TermID")] Fee fee)
        {
            if (id != fee.FeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeExists(fee.FeeID))
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
            ViewData["FeeTypeID"] = new SelectList(_context.FeeTypes, "FeeTypeID", "FeeTypeID", fee.FeeTypeID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", fee.StudentCourseID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermID", fee.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelID", fee.YearLevelID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", fee.SchoolYearID);
            return View(fee);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .Include(f => f.FeeType)
                .Include(f => f.StudentCourse)
                .Include(f => f.Term)
                .Include(f => f.YearLevel)
                .Include(f => f.SchoolYear)
                .FirstOrDefaultAsync(m => m.FeeID == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee != null)
            {
                _context.Fees.Remove(fee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeExists(Guid id)
        {
            return _context.Fees.Any(e => e.FeeID == id);
        }
    }
}
