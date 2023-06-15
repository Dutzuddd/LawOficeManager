using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicentaSfranciog.Models;
using LicentaSfranciog.Data;
using LicentaSfranciog.Models.ViewModels;

namespace LicentaSfranciog.Controllers
{
    public class CheltuieliController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public CheltuieliController(IDAL idal)
        {
            _idal = idal;
        }

        // GET: Cheltuieli
        public IActionResult Index(int id)
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetCheltuieliProces(id));
        }
       
        // GET: Cheltuieli/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var cheltuiala = _idal.GetCheltuiala((int)id);
            if (cheltuiala == null)
            {
                return NotFound();
            }

            return View(cheltuiala);
        }

        // GET: Cheltuieli/Create
        public IActionResult Create()
        {
            return View(new CheltuialaViewModel(_idal.GetProcese()));
        }

        // POST: Cheltuieli/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CheltuialaViewModel viewModel, IFormCollection form)
        {
            try
            {
                _idal.CreateCheltuiala(form);
                TempData["Alert"] = "Succes! Cheltuială introdusă pentru procesul: " + form["Proces"];
                return RedirectToAction("Index", "Procese");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Cheltuieli/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var cheltuiala = _idal.GetCheltuiala((int)id);
            if (cheltuiala == null)
            {
                return NotFound();
            }
            var vm = new CheltuialaViewModel(cheltuiala, _idal.GetProcese());
            return View(vm);
        }

        // POST: Cheltuieli/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormCollection form)
        {
            try
            {
                _idal.UpdateCheltuiala(form);
                TempData["Alert"] = "Succes! Date modificate pentru cheltuiala: "+ form["Cheltuiala.Titlu"];
                return RedirectToAction("Index", "Procese"); ;
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new CheltuialaViewModel(_idal.GetCheltuiala(id), _idal.GetProcese());
                return View(vm);
            }
        }

        // GET: Cheltuieli/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var cheltuiala = _idal.GetCheltuiala((int)id);
            if (cheltuiala == null)
            {
                return NotFound();
            }

            return View(cheltuiala);
        }

        // POST: Cheltuieli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteCheltuiala(id);
            TempData["Alert"] = "Cheltuială ştearsă!";
            return RedirectToAction("Index", "Procese");
        }

    }
}
