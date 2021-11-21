using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutriMais.Data;
using NutriMais.Models;
using NutriMais.Services.GoogleIntegration.EmailServices;
using NutriMais.Tasks.Appointment;

namespace NutriMais.Controllers
{
    [Authorize]
    public class CommunicationController : BaseController
    {
        private readonly NutriMaisContext _context;

        public CommunicationController(NutriMaisContext context)
        {
            _context = context;
        }

        // GET: Communication
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommunicationModel.ToListAsync());
        }

        // GET: Communication/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationModel = await _context.CommunicationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communicationModel == null)
            {
                return NotFound();
            }

            return View(communicationModel);
        }

        // GET: Communication/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Communication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Telefone,Description,Type,Id")] CommunicationModel communicationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(communicationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(communicationModel);
        }

        // GET: Communication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationModel = await _context.CommunicationModel.FindAsync(id);
            if (communicationModel == null)
            {
                return NotFound();
            }
            return View(communicationModel);
        }

        // POST: Communication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Telefone,Description,Type,Id")] CommunicationModel communicationModel)
        {
            if (id != communicationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(communicationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunicationModelExists(communicationModel.Id))
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
            return View(communicationModel);
        }

        // GET: Communication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communicationModel = await _context.CommunicationModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communicationModel == null)
            {
                return NotFound();
            }

            return View(communicationModel);
        }

        // POST: Communication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var communicationModel = await _context.CommunicationModel.FindAsync(id);
            _context.CommunicationModel.Remove(communicationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private void SendEmail()
        {

        }

        private bool CommunicationModelExists(int id)
        {
            return _context.CommunicationModel.Any(e => e.Id == id);
        }
    }
}
