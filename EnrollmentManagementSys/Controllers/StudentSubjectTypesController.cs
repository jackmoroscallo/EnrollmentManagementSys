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
    public class StudentSubjectTypesController : Controller
    {
        private readonly AppDBContext _context;

        public StudentSubjectTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: StudentSubjectTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentSubjectTypes.ToListAsync());
        }

        // GET: StudentSubjectTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectType = await _context.StudentSubjectTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (studentSubjectType == null)
            {
                return NotFound();
            }

            return View(studentSubjectType);
        }

        // GET: StudentSubjectTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentSubjectTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName")] StudentSubjectType studentSubjectType)
        {
            if (ModelState.IsValid)
            {
                studentSubjectType.TypeID = Guid.NewGuid();
                _context.Add(studentSubjectType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentSubjectType);
        }

        // GET: StudentSubjectTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectType = await _context.StudentSubjectTypes.FindAsync(id);
            if (studentSubjectType == null)
            {
                return NotFound();
            }
            return View(studentSubjectType);
        }

        // POST: StudentSubjectTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TypeId,TypeName")] StudentSubjectType studentSubjectType)
        {
            if (id != studentSubjectType.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentSubjectType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentSubjectTypeExists(studentSubjectType.TypeID))
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
            return View(studentSubjectType);
        }

        // GET: StudentSubjectTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentSubjectType = await _context.StudentSubjectTypes
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (studentSubjectType == null)
            {
                return NotFound();
            }

            return View(studentSubjectType);
        }

        // POST: StudentSubjectTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentSubjectType = await _context.StudentSubjectTypes.FindAsync(id);
            if (studentSubjectType != null)
            {
                _context.StudentSubjectTypes.Remove(studentSubjectType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentSubjectTypeExists(Guid id)
        {
            return _context.StudentSubjectTypes.Any(e => e.TypeID == id);
        }
    }
}
