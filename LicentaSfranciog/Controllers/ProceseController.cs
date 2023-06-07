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
    public class ProceseController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public ProceseController(IDAL dal)
        {
            _idal = dal;
        }

        // GET: Procese
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetProcese());
        }

        // GET: Procese/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @proces = _idal.GetProces((int)id);
            if (@proces == null)
            {
                return NotFound();
            }

            return View(@proces);
        }

        // GET: Procese/Create
        public IActionResult Create()
        {
            return View(new ProcesViewModel(_idal.GetClients()));
        }

        // POST: Procese/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcesViewModel viewModel,IFormCollection form)
        {
            try
            {
                _idal.CreateProces(form);
                TempData["Alert"] = "Succes! Proces introdus: " + form["Proces.Nume"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Procese/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var @proces = _idal.GetProces((int)id);
            if (@proces == null)
            {
                return NotFound();
            }
            var vm = new ProcesViewModel(@proces,_idal.GetClients());
            return View(vm);
        }

        // POST: Procese/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _idal.UpdateProces(form);
                TempData["Alert"] = "Succes! S-au modificat datele pentru procesul: " + form["Proces.Numme"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new ProcesViewModel(_idal.GetProces(id), _idal.GetClients());
                return View(vm);
            }
        }

        // GET: Procese/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var @proces = _idal.GetProces((int)id);
            if (@proces == null)
            {
                return NotFound();
            }
            return View(@proces);
        }

        // POST: Procese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteProces(id);
            TempData["Alert"] = "Succes!Proces sters!";
            return RedirectToAction(nameof(Index));
        }

        //private bool ProcesExists(int id)
        //{
        //  return (_context.Proces?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
