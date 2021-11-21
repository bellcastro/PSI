using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using NutriMais.Repositories.User;
using NutriMais.Models;
using NutriMais.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;


namespace NutriMais.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserRepositoryInterface _userRepository;
        private readonly NutriMaisContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;


        public SettingsController( UserRepositoryInterface userRepository, NutriMaisContext context, SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
        {
            _userRepository = userRepository;
            _context = context;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["User"] = await _userRepository.Find(User.Identity.GetUserId());
            return View();
        }
        public async Task<IActionResult> Alterar()
        {
            var user = await _userRepository.Find(User.Identity.GetUserId());
            ViewData["User"] = user;
            return View("Alterar");
        }

        public async Task<IActionResult> Desativar()
        {
            var user = await _userRepository.Find(User.Identity.GetUserId());
            ViewData["User"] = user;
            return View("Desativar");
        }

        public async Task<IActionResult> VincularNutri()
        {
            var user = await _userRepository.Find(User.Identity.GetUserId());
            ViewData["Pacients"] = await _userRepository.GetAvailablePacients();
            ViewData["DoctorPacients"] = await _userRepository.GetParticipantsFor(user);
            return View("VincularNutri");
        }

        [Route("/Settings/Pacient/Assign/{id}")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignPacient(string id)
        {
            if (id != null && id != "")
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    if(!user.ENutricionista)
                    {
                        return Unauthorized();
                    }

                    var pacient = await _userRepository.Find(id);
                    pacient.NutricionistaId = user.Id;
                    await _userRepository.UpdateUser(pacient);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        [Route("/Settings/Pacient/Remove/{id}")]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePacient(string id)
        {
            if (id != null && id != "")
            {
                try
                {
                    var user = await _userRepository.Find(User.Identity.GetUserId());
                    var pacient = await _userRepository.Find(id);
                    if ((user.ENutricionista && pacient.NutricionistaId == user.Id) || user.IsAdmin)
                    {
                        pacient.NutricionistaId = null;
                        await _userRepository.UpdateUser(pacient);
                        return Ok();
                    }

                     return Unauthorized();

                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Settings/User")]
        
        public async Task<IActionResult> AlterarNome([Bind("FullName")] UserModel model)
        {

            try
            {
                var user = await _userRepository.Find(User.Identity.GetUserId());
                user.FullName = model.FullName;
                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void OnGet()
        {
        }

        // public async Task<IActionResult> OnPost(string returnUrl = null)
        // {
        //     await _signInManager.SignOutAsync();
        //     _logger.LogInformation("User logged out.");
        //     if (returnUrl != null)
        //     {
        //         return LocalRedirect(returnUrl);
        //     }
        //     else
        //     {
        //         return RedirectToPage(returnUrl);
        //     }
        // }
        public async Task<IActionResult> DesativarConta()
        {
            try
            {
                var user = await _userRepository.Find(User.Identity.GetUserId());
                user.Ativado = false;
                _context.Update(user);
                await _signInManager.SignOutAsync();
                await _context.SaveChangesAsync();
                _logger.LogInformation("User logged out.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
            return View();
            }
        }

        // GET: HomeController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
