using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NutriMais.Models
{
	public abstract class AbstractModel
    {
        [Key]
        [DisplayName("Protocolo")]
        public int Id { get; set; }
    }
}
