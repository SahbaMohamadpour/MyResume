using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.SkillServiceFolder;
using App.DataAccess.Services.ProjrctServiceFolder;

namespace WebApplication1.Controllers
{
    public class SkillsController : Controller
    {
        ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _skillService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetById(id.Value);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Skill skill)
        {
            await _skillService.Add(skill);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SkillService = await _skillService.GetById(id.Value);
            if (SkillService == null)
            {
                return NotFound();
            }
            return View(SkillService);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Skill skills)
        {
            if (id != skills.Id)
            {
                return NotFound();
            }
            await _skillService.Update(id, skills);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetById(id.Value);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = _skillService.GetById(id);

            await _skillService.Delete(skill.Id);

            return RedirectToAction(nameof(Index));
        }




    }
}
