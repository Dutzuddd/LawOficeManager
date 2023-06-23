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
    public class EvenimenteController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _dal;

        public EvenimenteController(IDAL dal)
        {
            _dal = dal;
        }

        // GET: Evenimente
        public IActionResult Index()
        {
            if(TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetEvenimente());
        }

        // GET: Evenimente/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEveniment((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Evenimente/Create
        public IActionResult Create()
        {
            return View(new EventViewModel(_dal.GetLocatii()));
        }

        // POST: Evenimente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel viewModel, IFormCollection form)
        {
            try
            {
                _dal.CreateEveniment(form);
                TempData["Alert"] = "Succes! Eveniment introdus: " + form["Eveniment.Nume"];
                return RedirectToAction("Privacy", "Home");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Evenimente/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEveniment((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            var vm = new EventViewModel(@event, _dal.GetLocatii());
            return View(vm);
        }

        // POST: Evenimente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _dal.UpdateEveniment(form);
                TempData["Alert"] = "Succes! Date modificate pentru evenimentul: " + form["Eveniment.Nume"];
                return RedirectToAction("Privacy", "Home");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new EventViewModel(_dal.GetEveniment(id), _dal.GetLocatii());
                return View(vm);
            }
        }

        // GET: Evenimente/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEveniment((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            var vm = new EventViewModel(@event, _dal.GetLocatii());
            return View(@event);
        }

        // POST: Evenimente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteEveniment(id);
            TempData["Alert"] = "Evenitment şters!";
            return RedirectToAction(nameof(Index));
        }

        //private bool EvenimentExists(int id)
        //{
        //  return (_context.Evenimente?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
