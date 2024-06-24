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
    public class StudentSubjectsController : Controller
    {
        private readonly AppDBContext _context;

        public StudentSubjectsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: StudentSubjects
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.StudentSubjects.Include(s => s.StudentSubjectType).Include(s => s.StudentCourse);
            return View(await appDBContext.ToListAsync());
        }

        // GET: StudentSubjects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubjects
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentSubjectType)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // GET: StudentSubjects/Create
        public IActionResult Create()
        {
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["TypeID"] = new SelectList(_context.StudentSubjectTypes, "TypeID", "TypeName");
            return View();
        }

        // POST: StudentSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentCourseID,SubjectCode,SubjectDescription,Units,TypeID,SubjectHours")] StudentSubject studentSubject)
        {
            if (ModelState.IsValid)
            {
                studentSubject.SubjectId = Guid.NewGuid();
                _context.Add(studentSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", studentSubject.StudentCourseID);
            ViewData["TypeID"] = new SelectList(_context.StudentSubjectTypes, "TypeID", "TypeName", studentSubject.TypeID);
            return View(studentSubject);
        }

        // GET: StudentSubjects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubjects.FindAsync(id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", studentSubject.StudentCourseID);
            ViewData["TypeID"] = new SelectList(_context.StudentSubjectTypes, "TypeID", "TypeName", studentSubject.TypeID);
            return View(studentSubject);
        }


        // POST: StudentSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SubjectId,StudentCourseID,SubjectCode,SubjectDescription,Units,TypeID,SubjectHours")] StudentSubject studentSubject)
        {
            if (id != studentSubject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectExists(studentSubject.SubjectId))
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
            return View(studentSubject);
        }

        // GET: StudentSubjects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubject = await _context.StudentSubjects
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentSubjectType)
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (studentSubject == null)
            {
                return NotFound();
            }

            return View(studentSubject);
        }

        // POST: StudentSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentSubject = await _context.StudentSubjects.FindAsync(id);
            if (studentSubject != null)
            {
                _context.StudentSubjects.Remove(studentSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectExists(Guid id)
        {
            return _context.StudentSubjects.Any(e => e.SubjectId == id);
        }
    }
}
