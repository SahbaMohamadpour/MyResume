using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Domain.Models;
using App.Infrastructure;
using App.DataAccess.Services.CertificateServiceFolder;

namespace WebApplication1.Controllers
{
    public class CertificatesController : Controller
    {
        ICertificateService _certificateService;

        public CertificatesController(ICertificateService certificate)
        {
            _certificateService = certificate;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _certificateService.GetAll();
            return View(data);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _certificateService.GetById(id.Value);
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
        public async Task<IActionResult> Create(Certificate certificate)
        {
            await _certificateService.Add(certificate);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _certificateService.GetById(id.Value);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return NotFound();
            }
            await _certificateService.Update(id, certificate);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await _certificateService.GetById(id.Value);
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
            var data = _certificateService.GetById(id);

            await _certificateService.Delete(data.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}

