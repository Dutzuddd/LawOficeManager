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
    public class ClientiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public ClientiController(IDAL idal)
        {
            _idal = idal;
        }

        // GET: Clienti
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetClients());
        }

        // GET: Clienti/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @client = _idal.GetClient((int)id);
            if (@client == null)
            {
                return NotFound();
            }

            return View(@client);
        }

        // GET: Clienti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clienti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tip,Nume,Prenume,CNPorCUI,Telefon,Adresa,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _idal.CreateClient(client);
                    TempData["Alert"] = "Succes! S-a creat clientul: " + client.Nume;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "An error occurred: " + ex.Message;
                    return View(client);
                }
            }
            return View(client);
        }

        // GET: Clienti/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var @client = _idal.GetClient((int)id);
            if (@client == null)
            {
                return NotFound();
            }
            return View(@client);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            if (id != int.Parse(form["Id"]))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _idal.UpdateClient(form);
                    TempData["Alert"] = "Succes! S-au modificat datele pentru clientul: " + form["Nume"];
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(int.Parse(form["Id"])))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Clienti/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var @client = _idal.GetClient((int)id);
            if (@client == null)
            {
                return NotFound();
            }

            return View(@client);
        }

        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteClient(id);
            TempData["Alert"] = "Succes! A fost sters un client!";
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
          return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
