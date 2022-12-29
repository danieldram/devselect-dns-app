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
    public class Wtf : Controller
    {
        private readonly AppDBContext _context;

        public Wtf(AppDBContext context)
        {
            _context = context;
        }

        // GET: Wtf
        public async Task<IActionResult> Index()
        {
              return _context.WtfModel != null ? 
                          View(await _context.WtfModel.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.WtfModel'  is null.");
        }

        // GET: Wtf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WtfModel == null)
            {
                return NotFound();
            }

            var wtfModel = await _context.WtfModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wtfModel == null)
            {
                return NotFound();
            }

            return View(wtfModel);
        }

        // GET: Wtf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wtf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuckingBullshit")] WtfModel wtfModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wtfModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wtfModel);
        }

        // GET: Wtf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WtfModel == null)
            {
                return NotFound();
            }

            var wtfModel = await _context.WtfModel.FindAsync(id);
            if (wtfModel == null)
            {
                return NotFound();
            }
            return View(wtfModel);
        }

        // POST: Wtf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuckingBullshit")] WtfModel wtfModel)
        {
            if (id != wtfModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wtfModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WtfModelExists(wtfModel.Id))
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
            return View(wtfModel);
        }

        // GET: Wtf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WtfModel == null)
            {
                return NotFound();
            }

            var wtfModel = await _context.WtfModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wtfModel == null)
            {
                return NotFound();
            }

            return View(wtfModel);
        }

        // POST: Wtf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WtfModel == null)
            {
                return Problem("Entity set 'AppDBContext.WtfModel'  is null.");
            }
            var wtfModel = await _context.WtfModel.FindAsync(id);
            if (wtfModel != null)
            {
                _context.WtfModel.Remove(wtfModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WtfModelExists(int id)
        {
          return (_context.WtfModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
