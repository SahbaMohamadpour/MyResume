using App.DataAccess.Services.LanguageServiceFolder;
using App.DataAccess.Services.personalInfoServiceFolder;
using App.Domain.Models;
using App.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LanguagesController : Controller
    {
        ILanguageService _LanguageService;

        public LanguagesController(ILanguageService LanguageService)
        {
            _LanguageService = LanguageService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _LanguageService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _LanguageService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageService languageService)
        {
            await _LanguageService.Add(languageService);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _LanguageService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LanguageService languageService)
        {
            if (id != LanguageService.Id)
            {
                return NotFound();
            }
            await _LanguageService.Update(languageService);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _LanguageService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = _LanguageService.GetById(id);

            await _LanguageService.Remove(data.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
