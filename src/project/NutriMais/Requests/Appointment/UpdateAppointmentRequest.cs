using NutriMais.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutriMais.Requests.Appointment
{
    public class UpdateAppointmentRequest
    {
        [Required(ErrorMessage = "O Titulo da consulta é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A descrição da consulta é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O tipo da consulta é obrigatório.")]
        public AppointmentType Type { get; set; }

        [Required(ErrorMessage = "O campo quando é obrigatório.")]
        public DateTime StartsAt { get; set; }

        [Required(ErrorMessage = "O campo quando termina é obrigatório.")]
        public DateTime EndsAt { get; set; }
    }
}
