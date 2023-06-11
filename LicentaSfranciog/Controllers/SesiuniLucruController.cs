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
using Microsoft.Extensions.Logging;

namespace LicentaSfranciog.Controllers
{
    public class SesiuniLucruController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public SesiuniLucruController(IDAL dal)
        {
            _idal = dal;
        }

        // GET: SesiuniLucru
        public IActionResult Index(int id)
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetSesiuniProces(id));
        }

        // GET: SesiuniLucru/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
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

        // GET: SesiuniLucru/Create
        public IActionResult Create()
        {
            return View(new SesiuneLucruViewModel(_idal.GetProcese()));
        }

        // POST: SesiuniLucru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SesiuneLucruViewModel viewModel, IFormCollection form)
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

        // GET: SesiuniLucru/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
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
        public async Task<IActionResult> Edit(int id, IFormCollection form)
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

        // GET: SesiuniLucru/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteSesiune(id);
            TempData["Alert"] = "Sesiunea de Lucru ştearsă!";
            return RedirectToAction(nameof(Index));
        }

        //private bool SesiuneLucruExists(int id)
        //{
        //  return (_context.SeiuniDosar?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
