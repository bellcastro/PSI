using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriMais.Models
{
    [Table("AspNetUsers")]
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Ativado {get; set;}
        public string NutricionistaId {get; set;}
        public UserModel Nutricionista {get; set;}
        public bool ENutricionista {get; set;}

        public bool IsAvailable => NutricionistaId == null && ENutricionista == false;

        public Dictionary<string, object> Serialize()
        {
            return new Dictionary<string, object>()
            {
                { "id", Id },
                { "fullName", FullName },
            };
        }
    }
}
