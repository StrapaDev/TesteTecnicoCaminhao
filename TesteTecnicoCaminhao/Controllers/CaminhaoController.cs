using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteTecnicoCaminhao.Models;
using TesteTecnicoCaminhao.Services;

namespace TesteTecnicoCaminhao.Controllers
{
    public class CaminhaoController : Controller
    {
        private Contexto _context;
        private CaminhaoService _caminhaoService;

        public CaminhaoController(Contexto context)
        {
            _context = context;
            _caminhaoService = new CaminhaoService(_context);
        }

        public IActionResult Index()
        {
            return View(_caminhaoService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var caminhao = _caminhaoService.GetById(id.Value);
            if (caminhao == null)
                return NotFound();

            return View(caminhao);
        }

        public IActionResult Create()
        {
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Modelo,AnoFabricacao,AnoModelo")] Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                if (caminhao.AnoFabricacao != DateTime.Now.Year)
                {
                    ViewBag.msg = "O ano de fabricação deve ser o atual.";
                    return View(caminhao);
                }
                if (caminhao.AnoModelo != DateTime.Now.Year && caminhao.AnoModelo != DateTime.Now.Year + 1)
                {
                    ViewBag.msg = "O ano modelo deve ser o atual ou o ano subsequente.";
                    return View(caminhao);
                }
                _caminhaoService.Create(caminhao);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.msg = "";
            return View(caminhao);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var caminhao = _caminhaoService.GetById(id.Value);
            if (caminhao == null)
                return NotFound();

            ViewBag.msg = "";
            return View(caminhao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Modelo,AnoFabricacao,AnoModelo")] Caminhao caminhao)
        {
            if (id != caminhao.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (caminhao.AnoFabricacao != DateTime.Now.Year)
                {
                    ViewBag.msg = "O ano de fabricação deve ser o atual.";
                    return View(caminhao);
                }
                if (caminhao.AnoModelo != DateTime.Now.Year && caminhao.AnoModelo != DateTime.Now.Year + 1)
                {
                    ViewBag.msg = "O ano modelo deve ser o atual ou o ano subsequente.";
                    return View(caminhao);
                }
                try
                {
                    _caminhaoService.Update(caminhao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.msg = "";
            return View(caminhao);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var caminhao = _caminhaoService.GetById(id.Value);
            if (caminhao == null)
                return NotFound();

            return View(caminhao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var caminhao = _caminhaoService.GetById(id);
            _caminhaoService.Delete(caminhao);
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhoes.Any(e => e.Id == id);
        }
    }
}
