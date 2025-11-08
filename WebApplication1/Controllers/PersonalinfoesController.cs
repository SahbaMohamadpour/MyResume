using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.personalInfoServiceFolder;

namespace WebApplication1.Controllers
{
    public class PersonalinfoesController : Controller
    {
        IPersonalInfoService _personalInfoService;

        public PersonalinfoesController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        // GET: Personalinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personalinfos.ToListAsync());
        }

        // GET: Personalinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalinfo == null)
            {
                return NotFound();
            }

            return View(personalinfo);
        }

        // GET: Personalinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personalinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Image,Position,About,Email,Manifesto,Country,Website,LinkedIn,GitHub,Id,CreateAt,UpdateAt")] Personalinfo personalinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalinfo);
        }

        // GET: Personalinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfos.FindAsync(id);
            if (personalinfo == null)
            {
                return NotFound();
            }
            return View(personalinfo);
        }

        // POST: Personalinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Image,Position,About,Email,Manifesto,Country,Website,LinkedIn,GitHub,Id,CreateAt,UpdateAt")] Personalinfo personalinfo)
        {
            if (id != personalinfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalinfoExists(personalinfo.Id))
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
            return View(personalinfo);
        }

        // GET: Personalinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _context.Personalinfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalinfo == null)
            {
                return NotFound();
            }

            return View(personalinfo);
        }

        // POST: Personalinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalinfo = await _context.Personalinfos.FindAsync(id);
            if (personalinfo != null)
            {
                _context.Personalinfos.Remove(personalinfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalinfoExists(int id)
        {
            return _context.Personalinfos.Any(e => e.Id == id);
        }
    }
}
