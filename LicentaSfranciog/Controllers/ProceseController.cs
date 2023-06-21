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
using Microsoft.AspNetCore.Authorization;

namespace LicentaSfranciog.Controllers
{
    [Authorize]
    public class ProceseController : Controller
    {        
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
                TempData["Alert"] = "Succes! S-au modificat datele pentru procesul: " + form["Proces.Nume"];
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

        // Get: Proces/SesiuniLucrate
        public IActionResult SesiuniLucrate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiuni = _idal.GetSesiuniProces((int)id);
            if (sesiuni == null)
            {
                return NotFound();
            }
            return View(sesiuni);
        }
        //Create Sesiune Noua
        public IActionResult CreateSesiune()
        {
            return View(new SesiuneLucruViewModel(_idal.GetProcese()));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSesiune(SesiuneLucruViewModel viewModel, IFormCollection form)
        {
            try
            {
                _idal.CreateSesiune(form);
                TempData["Alert"] = "Succes! Sesiune introdusă pentru procesul: " + form["Proces"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }
        public IActionResult SesiuneDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiuneLucru = _idal.GetSesiune((int)id);
            if (sesiuneLucru == null)
            {
                return NotFound();
            }

            return View(sesiuneLucru);
        }

        public IActionResult EditSesiune(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiuneLucru = _idal.GetSesiune((int)id);
            if (sesiuneLucru == null)
            {
                return NotFound();
            }
            var vm = new SesiuneLucruViewModel(sesiuneLucru, _idal.GetProcese());
            return View(vm);
        }

        // POST: SesiuniLucru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSesiune(int id, IFormCollection form)
        {
            try
            {
                _idal.UpdateSesiune(form);
                TempData["Alert"] = "Succes! Date modificate pentru sesiunea de lucru!: "; /*+ form["Eveniment.Nume"];*/
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new SesiuneLucruViewModel(_idal.GetSesiune(id), _idal.GetProcese());
                return View(vm);
            }
        }
        public IActionResult DeleteSesiune(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesiuneLucru = _idal.GetSesiune((int)id);
            if (sesiuneLucru == null)
            {
                return NotFound();
            }

            return View(sesiuneLucru);
        }

        // POST: SesiuniLucru/Delete/5
        [HttpPost, ActionName("DeleteSesiune")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSesiuneConfirmed(int id)
        {
            _idal.DeleteSesiune(id);
            TempData["Alert"] = "Sesiunea de Lucru ştearsă!";
            return RedirectToAction(nameof(Index));
        }

    }
}
