
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NutriMais.Models;
using NutriMais.Repositories.Ficha;
using NutriMais.Repositories.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using NutriMais.Data;
using System.Linq;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NutriMais.Controllers
{
    [Authorize]
    public class FichaController : BaseController
    {
        private readonly UserRepositoryInterface _userRepository;
        private readonly FichaRepositoryInterface _fichaInterface;
        private readonly NutriMaisContext _context;

        public FichaController(UserRepositoryInterface userRepository, NutriMaisContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.FichaModel.ToListAsync());
        }

        // GET: Communication/Create
        public IActionResult Create(string userId)
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Nome,Email,Peso,Altura,QuantidadeAF,Rotina,AtividadeF")] FichaModel fichaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fichaModel);
                await _context.SaveChangesAsync();
                Response.StatusCode = StatusCodes.Status201Created;
                return RedirectToAction(nameof(Index));
            }

            return View(fichaModel);
        }

        // GET: Communication/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaModel = await _context.FichaModel.FindAsync(id);
            if (fichaModel == null)
            {
                return NotFound();
            }
            return View(fichaModel);
        }



        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titulo,Nome,Email,Peso,Altura,QuantidadeAF,Rotina,AtividadeF")] FichaModel fichaModel)
        {
            if (id != fichaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fichaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichaModelExists(fichaModel.Id))
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
            return View(fichaModel);
        }


        // GET: Communication/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fichaModel = await _context.FichaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fichaModel == null)
            {
                return NotFound();
            }

            return View(fichaModel);
        }

        // POST: Communication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fichaModel = await _context.FichaModel.FindAsync(id);
            _context.FichaModel.Remove(fichaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichaModelExists(int id)
        {
            return _context.FichaModel.Any(e => e.Id == id);
        }

        public ActionResult Listar()
        {
            var lista = new List<NutriMais.Models.FichaModel>();
           
            return View(lista);
        }
    }
}
