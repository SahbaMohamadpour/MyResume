using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.HobbiesServiceFolder;

namespace WebApplication1.Controllers
{
    public class HobbiesController : Controller
    {
        

        IHobbyService _HobbyService;

        public HobbiesController(IHobbyService HobbyService)
        {
            _HobbyService = HobbyService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _HobbyService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _HobbyService.GetById(id.Value);
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
        public async Task<IActionResult> Create(Hobbies hobbies)
        {
            await _HobbyService.Add(hobbies);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _HobbyService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hobbies hobbies)
        {
            if (id != hobbies.Id)
            {
                return NotFound();
            }
            await _HobbyService.Update(id, hobbies);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _HobbyService.GetById(id.Value);
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
            var data = _HobbyService.GetById(id);

            await _HobbyService.Delete(data.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
