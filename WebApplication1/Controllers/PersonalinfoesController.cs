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

        public async Task<IActionResult> Index()
        {
            var data = await _personalInfoService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _personalInfoService.GetById(id.Value);
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
        public async Task<IActionResult> Create(Personalinfo personalinfo)
        {
            await _personalInfoService.Add(personalinfo);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalinfo = await _personalInfoService.GetById(id.Value);
            if (personalinfo == null)
            {
                return NotFound();
            }
            return View(personalinfo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Personalinfo personalinfo)
        {
            if (id != personalinfo.Id)
            {
                return NotFound();
            }
            await _personalInfoService.Update(id,personalinfo);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _personalInfoService.GetById(id.Value);
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
            var Project = _personalInfoService.GetById(id);

            await _personalInfoService.Delete(Project.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
