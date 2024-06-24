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
    public class StudentsController : Controller
    {
        private readonly AppDBContext _context;

        public StudentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Students.Include(s => s.Gender).Include(s => s.StudentCourse).Include(s => s.StudentStatus).Include(s => s.YearLevel);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Gender)
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentStatus)
                .Include(s => s.YearLevel)
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Name");
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["StudentStatusID"] = new SelectList(_context.StudentStatuses, "StudentStatusID", "StatusName");
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels.OrderBy(x=>x.YearLevelNum), "YearLevelID", "YearLevelNum");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordID,StudentID,LastName,FirstName,MiddleName,StudentCourseID,YearLevelID,StudentStatusID,GenderID,Birthdate,Address,ContactNumber,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.RecordID = Guid.NewGuid();
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "GenderID", student.GenderID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "StudentCourseID", student.StudentCourseID);
            ViewData["StudentStatusID"] = new SelectList(_context.StudentStatuses, "StudentStatusID", "StudentStatusID", student.StudentStatusID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelID", student.YearLevelID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "Name", student.GenderID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", student.StudentCourseID);
            ViewData["StudentStatusID"] = new SelectList(_context.StudentStatuses, "StudentStatusID", "StatusName", student.StudentStatusID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelNum", student.YearLevelID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RecordID,StudentID,LastName,FirstName,MiddleName,StudentCourseID,YearLevelID,StudentStatusID,GenderID,Birthdate,Address,ContactNumber,Email")] Student student)
        {
            if (id != student.RecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.RecordID))
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
            ViewData["GenderID"] = new SelectList(_context.Genders, "GenderID", "GenderID", student.GenderID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "StudentCourseID", student.StudentCourseID);
            ViewData["StudentStatusID"] = new SelectList(_context.StudentStatuses, "StudentStatusID", "StudentStatusID", student.StudentStatusID);
            ViewData["YearLevelID"] = new SelectList(_context.YearLevels, "YearLevelID", "YearLevelID", student.YearLevelID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Gender)
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentStatus)
                .Include(s => s.YearLevel)
                .FirstOrDefaultAsync(m => m.RecordID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(Guid id)
        {
            return _context.Students.Any(e => e.RecordID == id);
        }
    }
}
