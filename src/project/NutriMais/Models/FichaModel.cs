using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NutriMais.Models
{


    [Table("Ficha")]
    public class FichaModel : AbstractModel
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        public string Titulo { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; }

        [DisplayName("Peso")]
        [Required(ErrorMessage = "O peso é obrigatório.")]
        public string Peso { get; set; }

        [DisplayName("Altura")]
        [Required(ErrorMessage = "A altura é obrigatório.")]
        public string Altura{ get; set; }

        [DisplayName("QuantidadeAF")]
        [Required(ErrorMessage = "A quantidade de atividade fisica é obrigatório.")]
        public string QuantidadeAF { get; set; }

        [DisplayName("Rotina")]
        [Required(ErrorMessage = "A altu é obrigatório.")]
        public string Rotina{ get; set; }

        [DisplayName("AtividadeF")]
        [Required(ErrorMessage = "A altu é obrigatório.")]
        public string AtividadeF { get; set; }
    }
}
