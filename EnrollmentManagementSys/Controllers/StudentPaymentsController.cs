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
    public class StudentPaymentsController : Controller
    {
        private readonly AppDBContext _context;

        public StudentPaymentsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: StudentPayments
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.StudentPayments.Include(s => s.Student).Include(s => s.ModeOfPayment).Include(s => s.PaymentType).Include(s => s.Term).Include(s => s.SchoolYear);
            return View(await appDBContext.ToListAsync());
        }

        // GET: StudentPayments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments
                .Include(s => s.Student)
                .Include(s => s.ModeOfPayment)
                .Include(s => s.PaymentType)
                .Include(s => s.Term)
                .Include(s => s.SchoolYear)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // GET: StudentPayments/Create
        public IActionResult Create()
        {
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentID");
            ViewData["ModeOfPaymentID"] = new SelectList(_context.ModeOfPayments, "ModeOfPaymentID", "ModeOfPaymentName");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "PaymentTypeName");
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName");
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName");
            return View();
        }

        // POST: StudentPayments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,RecordID,Description,Amount,PaymentTypeID,SchoolYearID,TermID,PaymentDate,ModeOfPaymentID,Details")] StudentPayment studentPayment)
        {
            if (ModelState.IsValid)
            {
                studentPayment.PaymentID = Guid.NewGuid();
                _context.Add(studentPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentID", studentPayment.RecordID);
            ViewData["ModeOfPaymentID"] = new SelectList(_context.ModeOfPayments, "ModeOfPaymentID", "ModeOfPaymentID", studentPayment.ModeOfPaymentID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "PaymentTypeID", studentPayment.PaymentTypeID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermID", studentPayment.TermID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearID", studentPayment.SchoolYearID);
            return View(studentPayment);
        }

        // GET: StudentPayments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments.FindAsync(id);
            if (studentPayment == null)
            {
                return NotFound();
            }
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo", studentPayment.RecordID);
            ViewData["ModeOfPaymentID"] = new SelectList(_context.ModeOfPayments, "ModeOfPaymentID", "ModeOfPaymentName", studentPayment.ModeOfPaymentID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "PaymentTypeName", studentPayment.PaymentTypeID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermName", studentPayment.TermID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearName", studentPayment.SchoolYearID);
            return View(studentPayment);
        }

        // POST: StudentPayments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaymentID,RecordID,Description,Amount,PaymentTypeID,SchoolYearID,TermID,PaymentDate,ModeOfPaymentID,Details")] StudentPayment studentPayment)
        {
            if (id != studentPayment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPaymentExists(studentPayment.PaymentID))
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
            ViewData["RecordID"] = new SelectList(_context.Students, "RecordID", "StudentInfo", studentPayment.RecordID);
            ViewData["ModeOfPaymentID"] = new SelectList(_context.ModeOfPayments, "ModeOfPaymentID", "ModeOfPaymentID", studentPayment.ModeOfPaymentID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "PaymentTypeID", studentPayment.PaymentTypeID);
            ViewData["TermID"] = new SelectList(_context.Terms, "TermID", "TermID", studentPayment.TermID);
            ViewData["SchoolYearID"] = new SelectList(_context.SchoolYears, "SchoolYearID", "SchoolYearID", studentPayment.SchoolYearID);
            return View(studentPayment);
        }

        // GET: StudentPayments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayments
                .Include(s => s.Student)
                .Include(s => s.ModeOfPayment)
                .Include(s => s.PaymentType)
                .Include(s => s.Term)
                .Include(s => s.SchoolYear)
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // POST: StudentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var studentPayment = await _context.StudentPayments.FindAsync(id);
            if (studentPayment != null)
            {
                _context.StudentPayments.Remove(studentPayment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPaymentExists(Guid id)
        {
            return _context.StudentPayments.Any(e => e.PaymentID == id);
        }
    }
}
