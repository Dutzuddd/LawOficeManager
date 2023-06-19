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
    public class FacturiController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public FacturiController(IDAL idal)
        {
            _idal = idal;
        }

        // GET: Facturi
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetFacturi());
        }

        // GET: Facturi/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var factura = _idal.GetFactura((int)id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturi/Create
        public IActionResult Create()
        {
            return View(new FacturaViewModel(_idal.GetProcese(), _idal.GetClients()));
        }

        // POST: Facturi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacturaViewModel viewModel, IFormCollection form)
        {
            try
            {
                _idal.CreateFactura(form);
                TempData["Alert"] = "Succes! Factură introdusă pentru procesul: " + form["Proces"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred" + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Facturi/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var factura = _idal.GetFactura((int)id);
            if (factura == null)
            {
                return NotFound();
            }
            var vm = new FacturaViewModel(factura, _idal.GetProcese(), _idal.GetClients());
            return View(vm);
        }

        // POST: Facturi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            try
            {
                _idal.UpdateFactura(form);
                TempData["Alert"] = "Succes! S-au modificat datele factruii pentru procesul: " + form["Proces"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new FacturaViewModel(_idal.GetFactura(id), _idal.GetProcese(), _idal.GetClients());
                return View(vm);
            }
        }

        // GET: Facturi/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var factura = _idal.GetFactura((int)id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteFactura(id);
            TempData["Alert"] = "Succes!Factură ştearsă!";
            return RedirectToAction(nameof(Index));
        }
        
    }
}
