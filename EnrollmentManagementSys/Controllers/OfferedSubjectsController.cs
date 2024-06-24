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
    public class OfferedSubjectsController : Controller
    {
        private readonly AppDBContext _context;

        public OfferedSubjectsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: OfferedSubjects
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.OfferedSubjects.Include(o => o.ClassType).Include(o => o.Semester).Include(o => o.StudentCourse).Include(o => o.StudentSubject).Include(o => o.SchoolYear);
            return View(await appDBContext.ToListAsync());
        }

        // GET: OfferedSubjects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offeredSubject = await _context.OfferedSubjects
                .Include(o => o.ClassType)
                .Include(o => o.Semester)
                .Include(o => o.StudentCourse)
                .Include(o => o.StudentSubject)
                .Include(o => o.SchoolYear)
                .FirstOrDefaultAsync(m => m.OfferedSubjectID == id);
            if (offeredSubject == null)
            {
                return NotFound();
            }

            return View(offeredSubject);
        }

        // GET: OfferedSubjects/Create
        public IActionResult Create()
        {
            ViewData["ClassTypeID"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeName");
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName");
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectInfo");
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName");
            return View();
        }

        // POST: OfferedSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfferedSubjectID,SubjectId,ClassTypeID,Capacity,DateOffered,SubjectRate,SchoolYearID,SemesterID,StudentCourseID,SubjectLevel")] OfferedSubject offeredSubject)
        {
            if (ModelState.IsValid)
            {
                offeredSubject.OfferedSubjectID = Guid.NewGuid();
                _context.Add(offeredSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassTypeID"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeName", offeredSubject.ClassTypeID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName", offeredSubject.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", offeredSubject.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectCode", offeredSubject.SubjectId);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", offeredSubject.SchoolYearID);
            return View(offeredSubject);
        }

        // GET: OfferedSubjects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offeredSubject = await _context.OfferedSubjects.FindAsync(id);
            if (offeredSubject == null)
            {
                return NotFound();
            }
            ViewData["ClassTypeID"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeName", offeredSubject.ClassTypeID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName", offeredSubject.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", offeredSubject.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectCode", offeredSubject.SubjectId);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", offeredSubject.SchoolYearID);
            return View(offeredSubject);
        }

        // POST: OfferedSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OfferedSubjectID,SubjectId,ClassTypeID,Capacity,DateOffered,SubjectRate,SchoolYearID,SemesterID,StudentCourseID,SubjectLevel")] OfferedSubject offeredSubject)
        {
            if (id != offeredSubject.OfferedSubjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offeredSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferedSubjectExists(offeredSubject.OfferedSubjectID))
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
            ViewData["ClassTypeID"] = new SelectList(_context.ClassTypes, "ClassTypeID", "ClassTypeName", offeredSubject.ClassTypeID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName", offeredSubject.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", offeredSubject.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectCode", offeredSubject.SubjectId);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", offeredSubject.SchoolYearID);
            return View(offeredSubject);
        }

        // GET: OfferedSubjects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offeredSubject = await _context.OfferedSubjects
                .Include(o => o.ClassType)
                .Include(o => o.Semester)
                .Include(o => o.StudentCourse)
                .Include(o => o.StudentSubject)
                .Include(o => o.SchoolYear)
                .FirstOrDefaultAsync(m => m.OfferedSubjectID == id);
            if (offeredSubject == null)
            {
                return NotFound();
            }

            return View(offeredSubject);
        }

        // POST: OfferedSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var offeredSubject = await _context.OfferedSubjects.FindAsync(id);
            if (offeredSubject != null)
            {
                _context.OfferedSubjects.Remove(offeredSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferedSubjectExists(Guid id)
        {
            return _context.OfferedSubjects.Any(e => e.OfferedSubjectID == id);
        }
    }
}
