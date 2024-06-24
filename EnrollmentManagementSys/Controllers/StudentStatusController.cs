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
    public class StudentStatusController : Controller
    {
        private readonly AppDBContext _context;

        public StudentStatusController(AppDBContext context)
        {
            _context = context;
        }

        // GET: StudentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentStatuses.ToListAsync());
        }

        // GET: StudentStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses
                .FirstOrDefaultAsync(m => m.StudentStatusID == id);
            if (studentStatus == null)
            {
                return NotFound();
            }

            return View(studentStatus);
        }

        // GET: StudentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentStatusID,StatusName")] StudentStatus studentStatus)
        {
            if (ModelState.IsValid)
            {
                studentStatus.StudentStatusID = Guid.NewGuid();
                _context.Add(studentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentStatus);
        }

        // GET: StudentStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses.FindAsync(id);
            if (studentStatus == null)
            {
                return NotFound();
            }
            return View(studentStatus);
        }

        // POST: StudentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("StudentStatusID,StatusName")] StudentStatus studentStatus)
        {
            if (id != studentStatus.StudentStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentStatusExists(studentStatus.StudentStatusID))
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
            return View(studentStatus);
        }

        // GET: StudentStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses
                .FirstOrDefaultAsync(m => m.StudentStatusID == id);
            if (studentStatus == null)
            {
                return NotFound();
            }

            return View(studentStatus);
        }

        // POST: StudentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentStatus = await _context.StudentStatuses.FindAsync(id);
            if (studentStatus != null)
            {
                _context.StudentStatuses.Remove(studentStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentStatusExists(Guid id)
        {
            return _context.StudentStatuses.Any(e => e.StudentStatusID == id);
        }
    }
}
