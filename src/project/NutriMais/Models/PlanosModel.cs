using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriMais.Models
{
	public enum DiaDaSemana
    {
        Segunda = 1,
        Terca,
        Quarta,
        Quinta, 
        Sexta,
        Sabado,
        Domingo
    }

    [Table("Planos")]
    public class PlanosModel : AbstractModel
    {
        [Required(ErrorMessage = "O Paciente é obrigatório.")]
        [ForeignKey("Paciente")]
        public string IdUsuario { get; set; }

        [DisplayName("Paciente")]
        public UserModel Paciente { get; set; }

        [DisplayName("DataInicioPlano")]
        public DateTime DataInicioPlano { get; set; }

        [DisplayName("DataFimPlano")]
        public DateTime DataFimPlano { get; set; }

        [DisplayName("ObservacoesPlano")]
        public string ObservacoesPlano { get; set; }
    }

    [Table("PlanosSemanal")]
    public class PlanoSemanalModel : AbstractModel
    {
        [Required(ErrorMessage = "O Paciente é obrigatório.")]
        [ForeignKey("Paciente")]
        public string UserId { get; set; }

        [DisplayName("Paciente")]
        public UserModel Paciente { get; set; }

        [DisplayName("IdPlano")]
        [ForeignKey("Plano")]
        public int IdPlano { get; set; }

        [DisplayName("Plano")]
        public PlanosModel Plano { get; set; }

        [DisplayName("DiaDaSemana")]
        public DiaDaSemana DiaDaSemana { get; set; }

        [DisplayName("PlanoTexto")]
        public string PlanoTexto { get; set; }
    }
}
