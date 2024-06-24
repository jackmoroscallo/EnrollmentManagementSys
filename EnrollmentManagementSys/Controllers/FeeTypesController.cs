﻿using System;
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
    public class FeeTypesController : Controller
    {
        private readonly AppDBContext _context;

        public FeeTypesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: FeeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeeTypes.ToListAsync());
        }

        // GET: FeeTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes
                .FirstOrDefaultAsync(m => m.FeeTypeID == id);
            if (feeType == null)
            {
                return NotFound();
            }

            return View(feeType);
        }

        // GET: FeeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeTypeID,FeeTypeName")] FeeType feeType)
        {
            if (ModelState.IsValid)
            {
                feeType.FeeTypeID = Guid.NewGuid();
                _context.Add(feeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feeType);
        }

        // GET: FeeTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes.FindAsync(id);
            if (feeType == null)
            {
                return NotFound();
            }
            return View(feeType);
        }

        // POST: FeeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FeeTypeID,FeeTypeName")] FeeType feeType)
        {
            if (id != feeType.FeeTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeTypeExists(feeType.FeeTypeID))
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
            return View(feeType);
        }

        // GET: FeeTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feeType = await _context.FeeTypes
                .FirstOrDefaultAsync(m => m.FeeTypeID == id);
            if (feeType == null)
            {
                return NotFound();
            }

            return View(feeType);
        }

        // POST: FeeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var feeType = await _context.FeeTypes.FindAsync(id);
            if (feeType != null)
            {
                _context.FeeTypes.Remove(feeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeTypeExists(Guid id)
        {
            return _context.FeeTypes.Any(e => e.FeeTypeID == id);
        }
    }
}
