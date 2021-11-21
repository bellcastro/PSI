using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriMais.Models;
using NutriMais.Repositories.Planos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NutriMais.Controllers
{
	[Authorize]
	public class PlanosController : BaseController
	{
		private readonly IPlanoRepositoryInterface _planoInterface;
		public PlanosController(IPlanoRepositoryInterface planoInterface) => _planoInterface = planoInterface;


		public IActionResult PlanosEReceitas(string idPLano, string userId)
		{
			try
			{
				PlanosModel planoUsuario;
				IEnumerable<PlanoSemanalModel> planoSemanal;

				if (idPLano is null && userId is null)
				{
					planoUsuario = _planoInterface.ObterPlano(User.Identity.GetUserId());
					if (planoUsuario != null)
						planoSemanal = _planoInterface.ObterPlanoSemanal(planoUsuario.Id);
					else planoSemanal = new List<PlanoSemanalModel>();
				}
				else
				{
					planoUsuario = _planoInterface.ObterPlano(userId);
					planoSemanal = _planoInterface.ObterPlanoSemanal(int.Parse(idPLano));
				}
				return View(new PlanoAtualViewModel(planoSemanal, planoUsuario));
			}
			catch (System.Exception)
			{
				var retorno = new List<PlanoSemanalModel> {
					new PlanoSemanalModel { IdPlano = 1, DiaDaSemana = DiaDaSemana.Segunda, PlanoTexto = "Comer de 2 em 2 min" },
					new PlanoSemanalModel { IdPlano = 2, DiaDaSemana = DiaDaSemana.Terca, PlanoTexto = "Comer de 2 em 2 min" },
					new PlanoSemanalModel { IdPlano = 3, DiaDaSemana = DiaDaSemana.Quarta, PlanoTexto = "Comer de 2 em 2 min" }
				};

				return View(new PlanoAtualViewModel(retorno, new PlanosModel()));
			}
		}

		public IActionResult AdicionarPlanoNutricional()
		{
			var retornoPlanoSemanal = new List<PlanoSemanalModel> {
					new PlanoSemanalModel { IdPlano = -1, DiaDaSemana = DiaDaSemana.Segunda },
					new PlanoSemanalModel { IdPlano = -1, DiaDaSemana = DiaDaSemana.Terca },
					new PlanoSemanalModel {  IdPlano = -1, DiaDaSemana = DiaDaSemana.Quarta },
					new PlanoSemanalModel {  IdPlano = -1, DiaDaSemana = DiaDaSemana.Quinta },
					new PlanoSemanalModel {  IdPlano = -1, DiaDaSemana = DiaDaSemana.Sexta },
					new PlanoSemanalModel {  IdPlano = -1, DiaDaSemana = DiaDaSemana.Sabado },
					new PlanoSemanalModel {  IdPlano = -1, DiaDaSemana = DiaDaSemana.Domingo },
				};

			var retornoPlano = new PlanosModel
			{
				Id = -1,
				IdUsuario = User.Identity.GetUserId()
			};

			return View("PlanosEReceitas", new PlanoAtualViewModel(retornoPlanoSemanal, retornoPlano));
		}

		[HttpDelete]
		public IActionResult DeletarPlano(string idPLano, string userId)
		{
			try
			{
				_planoInterface.DeletarPlano(userId, int.Parse(idPLano));
				return NoContent();
			}
			catch
			{
				return BadRequest();
			}

		}
		public IActionResult PlanoNutricional()
		{
			try
			{
				IEnumerable<PlanosModel> planoUsuario = _planoInterface.ObterPlanos(User.Identity.GetUserId());
				IEnumerable<PlanoSemanalModel> planosSemanal = _planoInterface.ObterPlanoSemanal(planoUsuario.Select(userPlans => userPlans.Id));

				return View(planosSemanal);
			}
			catch (System.Exception)
			{
				var retorno = new List<PlanoSemanalModel> {
					new PlanoSemanalModel { UserId = "1", IdPlano = 1, DiaDaSemana = DiaDaSemana.Segunda },
					new PlanoSemanalModel { UserId = "1", IdPlano = 2, DiaDaSemana = DiaDaSemana.Terca },
					new PlanoSemanalModel { UserId = "1",IdPlano = 3, DiaDaSemana = DiaDaSemana.Quarta }
				};
				return View(retorno);
			}

		}

		public IActionResult ReceitasView()
		{
			try
			{
				IEnumerable<PlanosModel> planoUsuario = _planoInterface.ObterPlanos(User.Identity.GetUserId());
				IEnumerable<PlanoSemanalModel> planosSemanal = _planoInterface.ObterPlanoSemanal(planoUsuario.Select(userPlans => userPlans.Id));

				return View(planosSemanal);
			}
			catch (System.Exception)
			{
				var retorno = new List<PlanoSemanalModel> {
					new PlanoSemanalModel { UserId = "1", IdPlano = 1, DiaDaSemana = DiaDaSemana.Segunda },
					new PlanoSemanalModel { UserId = "1", IdPlano = 2, DiaDaSemana = DiaDaSemana.Terca },
					new PlanoSemanalModel { UserId = "1",IdPlano = 3, DiaDaSemana = DiaDaSemana.Quarta }
				};
				return View(retorno);
			}
		}

		[HttpPatch]
		public IActionResult AtualizarPlano([FromBody] PlanoAtualViewModel planoViewModel)
		{
			try
			{
				int? idPlanoRequisicao = planoViewModel.PlanosSemanais.FirstOrDefault()?.Id;

				if (idPlanoRequisicao.HasValue && idPlanoRequisicao >= 0)
				{
					foreach (var plano in planoViewModel.PlanosSemanais)
						_planoInterface.AtualizarPlano(plano);
					return NoContent();
				}

				_planoInterface.InserirPlanoUsuario(planoViewModel.Plano);

				foreach (var plano in planoViewModel.PlanosSemanais)
					_planoInterface.InserirPlanoSemanal(plano);

				return NoContent();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
