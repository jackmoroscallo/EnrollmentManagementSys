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
    public class EnrollmentsController : Controller
    {
        private readonly AppDBContext _context;

        public EnrollmentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Enrollments.Include(e => e.EnrollmentStatuses).Include(e => e.Student).Include(e => e.SchoolYear).Include(e => e.StudentCourse).Include(e => e.Term).Include(e => e.YearLevel);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.EnrollmentStatuses)
                .Include(e => e.SchoolYear)
                .Include(e => e.StudentCourse)
                .Include(e => e.Term)
                .Include(e => e.YearLevel)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["EnrollmentStatusID"] = new SelectList(_context.EnrollmentsStatuses, "EnrollmentStatusID", "EnrollmentStatusName");
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName");
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName");
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum");
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentID,RecordID,StudentCourseID,YearLevelID,SchoolYearID,TermID,EnrollmentDate,EnrollmentStatusID")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.EnrollmentID = Guid.NewGuid();
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnrollmentStatusID"] = new SelectList(_context.EnrollmentsStatuses, "EnrollmentStatusID", "EnrollmentStatusName", enrollment.EnrollmentStatusID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", enrollment.SchoolYearID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", enrollment.StudentCourseID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName", enrollment.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum", enrollment.YearLevelID);
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo", enrollment.RecordID);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentStatusID"] = new SelectList(_context.EnrollmentsStatuses, "EnrollmentStatusID", "EnrollmentStatusName", enrollment.EnrollmentStatusID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", enrollment.SchoolYearID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", enrollment.StudentCourseID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName", enrollment.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum", enrollment.YearLevelID);
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo", enrollment.RecordID);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EnrollmentID,RecordID,StudentCourseID,YearLevelID,SchoolYearID,TermID,EnrollmentDate,EnrollmentStatusID")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentID))
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
            ViewData["EnrollmentStatusID"] = new SelectList(_context.EnrollmentsStatuses, "EnrollmentStatusID", "EnrollmentStatusName", enrollment.EnrollmentStatusID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", enrollment.SchoolYearID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", enrollment.StudentCourseID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName", enrollment.TermID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum", enrollment.YearLevelID);
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo", enrollment.RecordID);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.EnrollmentStatuses)
                .Include(e => e.SchoolYear)
                .Include(e => e.StudentCourse)
                .Include(e => e.Term)
                .Include(e => e.YearLevel)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(Guid id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
