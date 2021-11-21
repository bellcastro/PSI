using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace NutriMais.Models
{
    public enum CommunicationType
    {
        Chat,
        Email
    }
    [AllowAnonymous]
    [Table("Communications")]
    public class CommunicationModel : AbstractModel
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Title { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "A Description é obrigatório.")]
        public string Description { get; set; }

        [DisplayName("Tipo")]
        public CommunicationType Type { get; set; }


        public static Dictionary<int, string> GetAvailableTypes()
        {
            return new Dictionary<int, string>(){
                {0, "Chat" },
                {1, "Email" },
            };
        }


        public string TypeLabel => GetAvailableTypes()[(int)Type];


        public bool CanSeeCommunication(UserModel owner)
        {
            return owner.IsAdmin;
        }

    }
}
