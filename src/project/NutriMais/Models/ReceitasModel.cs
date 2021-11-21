using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriMais.Models
{
    [Table("Receita")]
    public class ReceitasModel : AbstractModel
	{
        [Required(ErrorMessage = "O Paciente é obrigatório.")]
        [ForeignKey("Paciente")]
        public string IdUsuario { get; set; }

        [DisplayName("Paciente")]
        public UserModel Paciente { get; set; }
        

        [DisplayName("DataCadastro")]
        public DateTime DataCadastro { get; set; }
        [DisplayName("TextoReceita")]
        public string TextoReceita { get; set; }             
    }
}
