using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.ProjrctServiceFolder;

namespace WebApplication1.Controllers
{
    public class ProjectsController : Controller
    {
        IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _projectService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectService = await _projectService.GetById(id.Value);
            if (projectService == null)
            {
                return NotFound();
            }

            return View(projectService);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            await _projectService.Add(project);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectService = await _projectService.GetById(id.Value);
            if (projectService == null)
            {
                return NotFound();
            }
            return View(projectService);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }
            await _projectService.Update(project);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Project = await _projectService.GetById(id.Value);
            if (Project == null)
            {
                return NotFound();
            }

            return View(Project);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var Project = _projectService.GetById(id);

            await _projectService.Remove(Project.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}
