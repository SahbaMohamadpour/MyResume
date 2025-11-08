using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;

namespace WebApplication1.Controllers
{
    public class ExpriencesController : Controller
    {
        private readonly DataContext _context;

        public ExpriencesController(DataContext context)
        {
            _context = context;
        }

        // GET: Expriences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expriences.ToListAsync());
        }

        // GET: Expriences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exprience = await _context.Expriences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exprience == null)
            {
                return NotFound();
            }

            return View(exprience);
        }

        // GET: Expriences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expriences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTitle,CompanyName,IsRemote,EmploymentType,Id,CreateAt,UpdateAt")] Exprience exprience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exprience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exprience);
        }

        // GET: Expriences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exprience = await _context.Expriences.FindAsync(id);
            if (exprience == null)
            {
                return NotFound();
            }
            return View(exprience);
        }

        // POST: Expriences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobTitle,CompanyName,IsRemote,EmploymentType,Id,CreateAt,UpdateAt")] Exprience exprience)
        {
            if (id != exprience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exprience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExprienceExists(exprience.Id))
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
            return View(exprience);
        }

        // GET: Expriences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exprience = await _context.Expriences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exprience == null)
            {
                return NotFound();
            }

            return View(exprience);
        }

        // POST: Expriences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exprience = await _context.Expriences.FindAsync(id);
            if (exprience != null)
            {
                _context.Expriences.Remove(exprience);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExprienceExists(int id)
        {
            return _context.Expriences.Any(e => e.Id == id);
        }
    }
}
