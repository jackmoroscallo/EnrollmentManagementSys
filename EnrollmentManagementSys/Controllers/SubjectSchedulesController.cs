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
    public class SubjectSchedulesController : Controller
    {
        private readonly AppDBContext _context;

        public SubjectSchedulesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: SubjectSchedules
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.SubjectSchedules.Include(s => s.Instructor).Include(s => s.Room).Include(s => s.SchoolYear).Include(s => s.Section).Include(s => s.Semester).Include(s => s.StudentCourse).Include(s => s.StudentSubject);
            return View(await appDBContext.ToListAsync());
        }

        // GET: SubjectSchedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectSchedule = await _context.SubjectSchedules
                .Include(s => s.Instructor)
                .Include(s => s.Room)
                .Include(s => s.SchoolYear)
                .Include(s => s.Section)
                .Include(s => s.Semester)
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentSubject)
                .FirstOrDefaultAsync(m => m.SubjectScheduleID == id);
            if (subjectSchedule == null)
            {
                return NotFound();
            }

            return View(subjectSchedule);
        }

        // GET: SubjectSchedules/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorInfo");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomName");
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName");
            ViewData["SectionID"] = new SelectList(_context.Sections, "SectionID", "SectionName");
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName");
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName");
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectInfo");
            return View();
        }

        // POST: SubjectSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectScheduleID,SubjectId,SubjectTimeStart,SubjectTimeEnd,SubjectDay,Mon,Tue,Wed,Thu,Fri,Sat,Sun,RoomID,InstructorID,StudentCourseID,SubjectLevel,SectionID,DateAdded,SchoolYearID,SemesterID")] SubjectSchedule subjectSchedule)
        {
            if (ModelState.IsValid)
            {
                subjectSchedule.SubjectScheduleID = Guid.NewGuid();
                _context.Add(subjectSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorInfo", subjectSchedule.InstructorID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomName", subjectSchedule.RoomID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", subjectSchedule.SchoolYearID);
            ViewData["SectionID"] = new SelectList(_context.Sections, "SectionID", "SectionName", subjectSchedule.SectionID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName", subjectSchedule.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", subjectSchedule.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectInfo", subjectSchedule.SubjectId);
            return View(subjectSchedule);
        }

        // GET: SubjectSchedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectSchedule = await _context.SubjectSchedules.FindAsync(id);
            if (subjectSchedule == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorInfo", subjectSchedule.InstructorID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomName", subjectSchedule.RoomID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", subjectSchedule.SchoolYearID);
            ViewData["SectionID"] = new SelectList(_context.Sections, "SectionID", "SectionName", subjectSchedule.SectionID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterName", subjectSchedule.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "CourseName", subjectSchedule.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectInfo", subjectSchedule.SubjectId);
            return View(subjectSchedule);
        }

        // POST: SubjectSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SubjectScheduleID,SubjectId,SubjectTimeStart,SubjectTimeEnd,SubjectDay,Mon,Tue,Wed,Thu,Fri,Sat,Sun,RoomID,InstructorID,StudentCourseID,SubjectLevel,SectionID,DateAdded,SchoolYearID,SemesterID")] SubjectSchedule subjectSchedule)
        {
            if (id != subjectSchedule.SubjectScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectScheduleExists(subjectSchedule.SubjectScheduleID))
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
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", subjectSchedule.InstructorID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "RoomID", "RoomID", subjectSchedule.RoomID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearID", subjectSchedule.SchoolYearID);
            ViewData["SectionID"] = new SelectList(_context.Sections, "SectionID", "SectionID", subjectSchedule.SectionID);
            ViewData["SemesterID"] = new SelectList(_context.Semesters, "SemesterID", "SemesterID", subjectSchedule.SemesterID);
            ViewData["StudentCourseID"] = new SelectList(_context.StudentsCourses, "StudentCourseID", "StudentCourseID", subjectSchedule.StudentCourseID);
            ViewData["SubjectId"] = new SelectList(_context.StudentSubjects, "SubjectId", "SubjectInfo", subjectSchedule.SubjectId);
            return View(subjectSchedule);
        }

        // GET: SubjectSchedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectSchedule = await _context.SubjectSchedules
                .Include(s => s.Instructor)
                .Include(s => s.Room)
                .Include(s => s.SchoolYear)
                .Include(s => s.Section)
                .Include(s => s.Semester)
                .Include(s => s.StudentCourse)
                .Include(s => s.StudentSubject)
                .FirstOrDefaultAsync(m => m.SubjectScheduleID == id);
            if (subjectSchedule == null)
            {
                return NotFound();
            }

            return View(subjectSchedule);
        }

        // POST: SubjectSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subjectSchedule = await _context.SubjectSchedules.FindAsync(id);
            if (subjectSchedule != null)
            {
                _context.SubjectSchedules.Remove(subjectSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectScheduleExists(Guid id)
        {
            return _context.SubjectSchedules.Any(e => e.SubjectScheduleID == id);
        }
    }
}
