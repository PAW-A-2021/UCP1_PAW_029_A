using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1.Models;

namespace UCP1.Controllers
{
    public class DetailsController : Controller
    {
        private readonly PBarangContext _context;

        public DetailsController(PBarangContext context)
        {
            _context = context;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
            var pBarangContext = _context.Details.Include(d => d.IdAdministratorNavigation).Include(d => d.IdCustomerNavigation).Include(d => d.IdDetailBarangNavigation).Include(d => d.IdKurirNavigation);
            return View(await pBarangContext.ToListAsync());
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.IdAdministratorNavigation)
                .Include(d => d.IdCustomerNavigation)
                .Include(d => d.IdDetailBarangNavigation)
                .Include(d => d.IdKurirNavigation)
                .FirstOrDefaultAsync(m => m.IdDetailBarang == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            ViewData["IdAdministrator"] = new SelectList(_context.Administrators, "IdAdministrator", "IdAdministrator");
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer");
            ViewData["IdDetailBarang"] = new SelectList(_context.Barangs, "IdDetailBarang", "IdDetailBarang");
            ViewData["IdKurir"] = new SelectList(_context.Kurirs, "IdKurir", "IdKurir");
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetailBarang,NomorResiPengiriman,IdCustomer,IdAdministrator,IdKurir")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdministrator"] = new SelectList(_context.Administrators, "IdAdministrator", "IdAdministrator", detail.IdAdministrator);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", detail.IdCustomer);
            ViewData["IdDetailBarang"] = new SelectList(_context.Barangs, "IdDetailBarang", "IdDetailBarang", detail.IdDetailBarang);
            ViewData["IdKurir"] = new SelectList(_context.Kurirs, "IdKurir", "IdKurir", detail.IdKurir);
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            ViewData["IdAdministrator"] = new SelectList(_context.Administrators, "IdAdministrator", "IdAdministrator", detail.IdAdministrator);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", detail.IdCustomer);
            ViewData["IdDetailBarang"] = new SelectList(_context.Barangs, "IdDetailBarang", "IdDetailBarang", detail.IdDetailBarang);
            ViewData["IdKurir"] = new SelectList(_context.Kurirs, "IdKurir", "IdKurir", detail.IdKurir);
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetailBarang,NomorResiPengiriman,IdCustomer,IdAdministrator,IdKurir")] Detail detail)
        {
            if (id != detail.IdDetailBarang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.IdDetailBarang))
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
            ViewData["IdAdministrator"] = new SelectList(_context.Administrators, "IdAdministrator", "IdAdministrator", detail.IdAdministrator);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", detail.IdCustomer);
            ViewData["IdDetailBarang"] = new SelectList(_context.Barangs, "IdDetailBarang", "IdDetailBarang", detail.IdDetailBarang);
            ViewData["IdKurir"] = new SelectList(_context.Kurirs, "IdKurir", "IdKurir", detail.IdKurir);
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.Details
                .Include(d => d.IdAdministratorNavigation)
                .Include(d => d.IdCustomerNavigation)
                .Include(d => d.IdDetailBarangNavigation)
                .Include(d => d.IdKurirNavigation)
                .FirstOrDefaultAsync(m => m.IdDetailBarang == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail = await _context.Details.FindAsync(id);
            _context.Details.Remove(detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
            return _context.Details.Any(e => e.IdDetailBarang == id);
        }
    }
}
