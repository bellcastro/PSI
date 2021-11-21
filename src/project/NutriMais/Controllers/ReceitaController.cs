using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriMais.Models;
using NutriMais.Repositories.Receitas;
using System.Collections.Generic;
using System.Linq;

namespace NutriMais.Controllers
{
	[Authorize]
	public class ReceitaController : BaseController
	{
		private readonly IReceitaRepository _receitaRepository;
		public ReceitaController(IReceitaRepository receitaRepository) => _receitaRepository = receitaRepository;

		public IActionResult ReceitaView(string idReceita)
		{
			try
			{
				ReceitasModel receita = _receitaRepository.ObterReceitas(User.Identity.GetUserId()).FirstOrDefault(receita => receita.Id == int.Parse(idReceita));			
				return View(receita);
			}
			catch (System.Exception)
			{
				return View(new ReceitasModel { Id = 1, TextoReceita = "Comer de 2 em 2 horas" });
			}

		}

		public IActionResult ReceitasView() 
		{
			try
			{
				IEnumerable<ReceitasModel> receitas = _receitaRepository.ObterReceitas(User.Identity.GetUserId())?.ToList();				
				return View(receitas);
			}
			catch (System.Exception)
			{
				IEnumerable<ReceitasModel> receitas = new List<ReceitasModel>
				{
					new ReceitasModel{ Id = 1, TextoReceita = "Comer de 2 em 2 horas"}
				};

				return View(receitas);				
			}
		
		}

		[HttpDelete]
		public IActionResult DeletarReceita(string idReceita)
		{
			try
			{
				_receitaRepository.DeletarReceitas(User.Identity.GetUserId(), int.Parse(idReceita));
				return NoContent(); 
			}
			catch
			{ 
				return BadRequest();				
			}
		}



	}
}
