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
    public class RapoarteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public RapoarteController(IDAL idal)
        {
            _idal = idal;
        }

        // GET: Rapoarte
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetRapoarte());
        }

        // GET: Rapoarte/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var raport = _idal.GetRaport((int)id);
            if (raport == null)
            {
                return NotFound();
            }

            return View(raport);
        }

        // GET: Rapoarte/Create
        public IActionResult Create()
        {
            return View(new RaportViewModel(_idal.GetProcese()));
        }

        // POST: Rapoarte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RaportViewModel viewModel, IFormCollection form)
        {
            try
            {
                _idal.CreateRaport(form);
                TempData["Alert"] = "Succes! Raport introdus pentru procesul: " + form["Proces"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }
               

        // GET: Rapoarte/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var raport = _idal.GetRaport((int)id);
            if (raport == null)
            {
                return NotFound();
            }

            return View(raport);
        }

        // POST: Rapoarte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteRaport(id);
            TempData["Alert"] = "Succes!Raport sters!";
            return RedirectToAction(nameof(Index));
        }

        private bool RaportExists(int id)
        {
          return (_context.Rapoarte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
