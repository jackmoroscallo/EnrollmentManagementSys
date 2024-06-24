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
    public class EnrollmentStatusController : Controller
    {
        private readonly AppDBContext _context;

        public EnrollmentStatusController(AppDBContext context)
        {
            _context = context;
        }

        // GET: EnrollmentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnrollmentsStatuses.ToListAsync());
        }

        // GET: EnrollmentStatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentStatus = await _context.EnrollmentsStatuses
                .FirstOrDefaultAsync(m => m.EnrollmentStatusID == id);
            if (enrollmentStatus == null)
            {
                return NotFound();
            }

            return View(enrollmentStatus);
        }

        // GET: EnrollmentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentStatusID,EnrollmentStatusName")] EnrollmentStatus enrollmentStatus)
        {
            if (ModelState.IsValid)
            {
                enrollmentStatus.EnrollmentStatusID = Guid.NewGuid();
                _context.Add(enrollmentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrollmentStatus);
        }

        // GET: EnrollmentStatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentStatus = await _context.EnrollmentsStatuses.FindAsync(id);
            if (enrollmentStatus == null)
            {
                return NotFound();
            }
            return View(enrollmentStatus);
        }

        // POST: EnrollmentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EnrollmentStatusID,EnrollmentStatusName")] EnrollmentStatus enrollmentStatus)
        {
            if (id != enrollmentStatus.EnrollmentStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollmentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentStatusExists(enrollmentStatus.EnrollmentStatusID))
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
            return View(enrollmentStatus);
        }

        // GET: EnrollmentStatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentStatus = await _context.EnrollmentsStatuses
                .FirstOrDefaultAsync(m => m.EnrollmentStatusID == id);
            if (enrollmentStatus == null)
            {
                return NotFound();
            }

            return View(enrollmentStatus);
        }

        // POST: EnrollmentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var enrollmentStatus = await _context.EnrollmentsStatuses.FindAsync(id);
            if (enrollmentStatus != null)
            {
                _context.EnrollmentsStatuses.Remove(enrollmentStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentStatusExists(Guid id)
        {
            return _context.EnrollmentsStatuses.Any(e => e.EnrollmentStatusID == id);
        }
    }
}
