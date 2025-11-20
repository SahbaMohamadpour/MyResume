using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.ExprienceServiceFolder;

namespace WebApplication1.Controllers
{
    public class ExpriencesController : Controller
    {
        IExprienceService _exprienceService;

        public ExpriencesController(IExprienceService Exprience)
        {
            _exprienceService = Exprience;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _exprienceService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _exprienceService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exprience exprience)
        {
            await _exprienceService.Add(exprience);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _exprienceService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Exprience exprience)
        {
            if (id != exprience.Id)
            {
                return NotFound();
            }
            await _exprienceService.Update(id, exprience);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _exprienceService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _exprienceService.GetById(id);

            await _exprienceService.Delete(data.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
