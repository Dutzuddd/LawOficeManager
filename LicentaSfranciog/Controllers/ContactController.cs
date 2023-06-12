using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicentaSfranciog.Models;
using LicentaSfranciog.Data;

namespace LicentaSfranciog.Controllers
{
    public class ContactController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly IDAL _idal;

        public ContactController(IDAL idal)
        {
            _idal = idal;
        }

        // GET: Contact
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_idal.GetContacte());
        }

        // GET: Contact/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var contact = _idal.GetContact((int)id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Telefon,Email,Mesaj")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _idal.CreateContact(contact);
                    TempData["Alert"] = "Succes! " + contact.Nume+" mesajul tău a fost trimis! " ;
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "An error occurred: " + ex.Message;
                    return View(contact);
                }
            }
            return View(contact); ;
        }
       
        // GET: Contact/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var contact = _idal.GetContact((int)id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _idal.DeleteContact(id);
            TempData["Alert"] = "Succes! Mesaj sters!";
            return RedirectToAction(nameof(Index));
        }
        
    }
}
