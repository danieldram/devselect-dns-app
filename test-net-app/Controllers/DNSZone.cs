using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_net_app.Data;
using test_net_app.Models;

namespace test_net_app.Controllers
{
    public class DNSZone : Controller
    {
        private readonly AppDBContext _context;

        public DNSZone(AppDBContext context)
        {
            _context = context;
        }

        // GET: DNSZone
        public async Task<IActionResult> Index()
        {
              return _context.DNSZones != null ? 
                          View(await _context.DNSZones.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.DNSZones'  is null.");
        }

        // GET: DNSZone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DNSZones == null)
            {
                return NotFound();
            }

            var dNSZones = await _context.DNSZones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dNSZones == null)
            {
                return NotFound();
            }

            return View(dNSZones);
        }

        // GET: DNSZone/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DNSZone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Doamin,IP,Email,TTL,Refresh,Retry,Expire,MTTL,NS1,NS2,NS3,NS4")] DNSZones dNSZones)
        {
            var DomainExists = _context.DNSZones.Where(zone => zone.Doamin == dNSZones.Doamin).Count() > 0;

            if (DomainExists)
            {
                TempData["Error"] = "Domain already exists.";
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                _context.Add(dNSZones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dNSZones);
        }

        // GET: DNSZone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DNSZones == null)
            {
                return NotFound();
            }

            var dNSZones = await _context.DNSZones.FindAsync(id);
            if (dNSZones == null)
            {
                return NotFound();
            }
            return View(dNSZones);
        }

        // POST: DNSZone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Doamin,IP,Email,TTL,Refresh,Retry,Expire,MTTL,NS1,NS2,NS3,NS4")] DNSZones dNSZones)
        {
            if (id != dNSZones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dNSZones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DNSZonesExists(dNSZones.Id))
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
            return View(dNSZones);
        }

        // GET: DNSZone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DNSZones == null)
            {
                return NotFound();
            }

            var dNSZones = await _context.DNSZones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dNSZones == null)
            {
                return NotFound();
            }

            return View(dNSZones);
        }

        // POST: DNSZone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DNSZones == null)
            {
                return Problem("Entity set 'AppDBContext.DNSZones'  is null.");
            }
            var dNSZones = await _context.DNSZones.FindAsync(id);
            if (dNSZones != null)
            {
                _context.DNSRecords.RemoveRange(_context.DNSRecords.Where(record => record.ZoneId == id));
                _context.DNSZones.Remove(dNSZones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DNSZonesExists(int id)
        {
          return (_context.DNSZones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
