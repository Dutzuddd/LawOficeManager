using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicentaSfranciog.Models;
using LicentaSfranciog.Data;
using Microsoft.CodeAnalysis;

namespace LicentaSfranciog.Controllers
{
    public class LocatiiController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _dal;

        public LocatiiController(IDAL idal)
        {
            _dal = idal;
        }

        // GET: Locatii
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
               ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetLocatii());
        }

        // GET: Locatii/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _dal.GetLoc((int)id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locatii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locatii/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adresa")] Loc loc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreateLoc(loc);
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

               

        // GET: Locatii/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var loc = _dal.GetLoc((int)id);
            if (loc == null)
            {
                return NotFound();
            }

            return View(loc);
        }

        // POST: Locatii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _dal.DeleteLoc(id);
            TempData["Alert"] = "Succes! A fost sters un loc!";
            return RedirectToAction(nameof(Index));
        }

       
    }
}
