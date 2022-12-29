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
    public class DNSRecord : Controller
    {
        private readonly AppDBContext _context;

        public DNSRecord(AppDBContext context)
        {
            _context = context;
        }

        // GET: DNSRecord
        public async Task<IActionResult> Index()
        {
              return _context.DNSRecords != null ? 
                          View(await _context.DNSRecords.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.DNSRecords'  is null.");
        }

        // GET: DNSRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DNSRecords == null)
            {
                return NotFound();
            }

            var dNSRecords = await _context.DNSRecords
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            if (dNSRecords == null)
            {
                return NotFound();
            }

            return View(dNSRecords);
        }

        // GET: DNSRecord/Create
        public IActionResult Create(int ZoneId, string Name)
        {
            return View();
        }

        // POST: DNSRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZoneId,Name,TTL,RecordClass,RecordType,RecordData")] DNSRecords dNSRecords)
        {
            var hasTooMany = _context.DNSRecords.Where(record => record.ZoneId == dNSRecords.ZoneId).Count() >= 10;
            if (hasTooMany)
            {
                TempData["Error"] = "There are too many records for this zone.";
                return RedirectToAction("Index", new {controller="DNSZone", action="Index"});
            }
            if (ModelState.IsValid)
            {
                _context.Add(dNSRecords);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dNSRecords);
        }

        // GET: DNSRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DNSRecords == null)
            {
                return NotFound();
            }

            var dNSRecords = await _context.DNSRecords.FindAsync(id);
            if (dNSRecords == null)
            {
                return NotFound();
            }
            return View(dNSRecords);
        }

        // POST: DNSRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZoneId,Name,TTL,RecordClass,RecordType,RecordData")] DNSRecords dNSRecords)
        {
            if (id != dNSRecords.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dNSRecords);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DNSRecordsExists(dNSRecords.Id))
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
            return View(dNSRecords);
        }

        // GET: DNSRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DNSRecords == null)
            {
                return NotFound();
            }

            var dNSRecords = await _context.DNSRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dNSRecords == null)
            {
                return NotFound();
            }

            return View(dNSRecords);
        }

        // POST: DNSRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DNSRecords == null)
            {
                return Problem("Entity set 'AppDBContext.DNSRecords'  is null.");
            }
            var dNSRecords = await _context.DNSRecords.FindAsync(id);
            if (dNSRecords != null)
            {
                _context.DNSRecords.Remove(dNSRecords);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DNSRecordsExists(int id)
        {
          return (_context.DNSRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
