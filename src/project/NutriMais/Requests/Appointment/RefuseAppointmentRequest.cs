using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Requests.Appointment
{
    public class RefuseAppointmentRequest
    {
        [Required(ErrorMessage = "Para a recusa o campo razão é obrigatorio")]
        public string Reason;
    }
}
