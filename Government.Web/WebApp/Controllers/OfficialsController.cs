using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OfficialsController : Controller
    {
        private readonly GovContext _context;

        public OfficialsController(GovContext context)
        {
            _context = context;
        }

        // GET: Officials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Official.ToListAsync());
        }

        // GET: Officials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var official = await _context.Official
                .FirstOrDefaultAsync(m => m.Id == id);
            if (official == null)
            {
                return NotFound();
            }

            return View(official);
        }

        // GET: Officials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Officials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Position,MunicipalityId")] Official official)
        {
            if (ModelState.IsValid)
            {
                official.Id = Guid.NewGuid();
                _context.Add(official);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(official);
        }

        // GET: Officials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var official = await _context.Official.FindAsync(id);
            if (official == null)
            {
                return NotFound();
            }
            return View(official);
        }

        // POST: Officials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Position,MunicipalityId")] Official official)
        {
            if (id != official.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(official);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficialExists(official.Id))
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
            return View(official);
        }

        // GET: Officials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var official = await _context.Official
                .FirstOrDefaultAsync(m => m.Id == id);
            if (official == null)
            {
                return NotFound();
            }

            return View(official);
        }

        // POST: Officials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var official = await _context.Official.FindAsync(id);
            _context.Official.Remove(official);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficialExists(Guid id)
        {
            return _context.Official.Any(e => e.Id == id);
        }
    }
}
