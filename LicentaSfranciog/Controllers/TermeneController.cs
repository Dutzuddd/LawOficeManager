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
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace LicentaSfranciog.Controllers
{
    [Authorize]
    public class TermeneController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public TermeneController(IDAL dal)
        {
            _idal = dal;
        }

        // GET: Termene
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetTermene());
        }

        // GET: Termene/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var termen = _idal.GetTermen((int)id);
            if (termen == null)
            {
                return NotFound();
            }

            return View(termen);
        }

        // GET: Termene/Create
        public IActionResult Create()
        {
            return View(new TermenViewModel(_idal.GetProcese(), _idal.GetLocatii()));
        }

        // POST: Termene/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TermenViewModel viewModel, IFormCollection form)
        {
            try
            {
                _idal.CreateTermen(form);
                TempData["Alert"] = "Succes! Termen introdus: " + form["Termen.Nume"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Termene/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var termen = _idal.GetTermen((int)id);
            if (termen == null)
            {
                return NotFound();
            }
            var vm = new TermenViewModel(termen, _idal.GetProcese(), _idal.GetLocatii());
            return View(vm);
        }

        // POST: Termene/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _idal.UpdateTermen(form);
                TempData["Alert"] = "Succes! S-au modificat datele pentru termenul: " + form["Termen.Nume"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new TermenViewModel(_idal.GetTermen(id), _idal.GetProcese(), _idal.GetLocatii());
                return View(vm);
            }
        }

        // GET: Termene/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var termen = _idal.GetTermen((int)id);
            if (termen == null)
            {
                return NotFound();
            }

            return View(termen);
        }

        // POST: Termene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteTermen(id);
            TempData["Alert"] = "Succes!Termen sters!";
            return RedirectToAction(nameof(Index));
        }


        //Create Loc
        public IActionResult CreateLoc()
        {
            return View();
        }

        // POST: Locatii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLoc([Bind("Id,Name,Adresa")] Loc loc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _idal.CreateLoc(loc);
                    TempData["Alert"] = "Succes! Loc adăugat: " + loc.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "An error occurred: " + ex.Message;
                    return View(loc);
                }
            }
            return View(loc);
        }
    }
}
