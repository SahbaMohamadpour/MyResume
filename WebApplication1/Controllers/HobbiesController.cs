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
    public class HobbiesController : Controller
    {
        private readonly DataContext _context;

        public HobbiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hobby.ToListAsync());
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobbies == null)
            {
                return NotFound();
            }

            return View(hobbies);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hobbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreateAt,UpdateAt")] Hobbies hobbies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobbies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hobbies);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobby.FindAsync(id);
            if (hobbies == null)
            {
                return NotFound();
            }
            return View(hobbies);
        }

        // POST: Hobbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreateAt,UpdateAt")] Hobbies hobbies)
        {
            if (id != hobbies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobbies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbiesExists(hobbies.Id))
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
            return View(hobbies);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobbies = await _context.Hobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobbies == null)
            {
                return NotFound();
            }

            return View(hobbies);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobbies = await _context.Hobby.FindAsync(id);
            if (hobbies != null)
            {
                _context.Hobby.Remove(hobbies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbiesExists(int id)
        {
            return _context.Hobby.Any(e => e.Id == id);
        }
    }
}
