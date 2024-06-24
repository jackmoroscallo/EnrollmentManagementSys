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
    public class ModeOfPaymentsController : Controller
    {
        private readonly AppDBContext _context;

        public ModeOfPaymentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ModeOfPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeOfPayments.ToListAsync());
        }

        // GET: ModeOfPayments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeOfPayment = await _context.ModeOfPayments
                .FirstOrDefaultAsync(m => m.ModeOfPaymentID == id);
            if (modeOfPayment == null)
            {
                return NotFound();
            }

            return View(modeOfPayment);
        }

        // GET: ModeOfPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeOfPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeOfPaymentID,ModeOfPaymentName")] ModeOfPayment modeOfPayment)
        {
            if (ModelState.IsValid)
            {
                modeOfPayment.ModeOfPaymentID = Guid.NewGuid();
                _context.Add(modeOfPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeOfPayment);
        }

        // GET: ModeOfPayments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeOfPayment = await _context.ModeOfPayments.FindAsync(id);
            if (modeOfPayment == null)
            {
                return NotFound();
            }
            return View(modeOfPayment);
        }

        // POST: ModeOfPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ModeOfPaymentID,ModeOfPaymentName")] ModeOfPayment modeOfPayment)
        {
            if (id != modeOfPayment.ModeOfPaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeOfPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeOfPaymentExists(modeOfPayment.ModeOfPaymentID))
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
            return View(modeOfPayment);
        }

        // GET: ModeOfPayments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeOfPayment = await _context.ModeOfPayments
                .FirstOrDefaultAsync(m => m.ModeOfPaymentID == id);
            if (modeOfPayment == null)
            {
                return NotFound();
            }

            return View(modeOfPayment);
        }

        // POST: ModeOfPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modeOfPayment = await _context.ModeOfPayments.FindAsync(id);
            if (modeOfPayment != null)
            {
                _context.ModeOfPayments.Remove(modeOfPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeOfPaymentExists(Guid id)
        {
            return _context.ModeOfPayments.Any(e => e.ModeOfPaymentID == id);
        }
    }
}
