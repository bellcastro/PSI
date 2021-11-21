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
    public enum AppointmentType
    {
        Virtual,
        OnLocation
    }

    public enum AppointmentStatus
    {
        Draft,
        Confirmed,
        Refused,
        Cancelled
    }

    [Table("Appointments")]
    public class AppointmentModel : AbstractModel
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo da consulta é obrigatório.")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "A descrição da consulta é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O tipo da consulta é obrigatório.")]
        [DisplayName("Tipo")]
        public AppointmentType Type { get; set; }

        [DisplayName("Status")]
        [JsonIgnore]
        public AppointmentStatus Status { get; set; }

        [Required(ErrorMessage = "O campo quando é obrigatório.")]
        [DisplayName("Quando")]
        public DateTime StartsAt { get; set; }

        [Required(ErrorMessage = "O campo quando termina é obrigatório.")]
        [DisplayName("Quando")]
        public DateTime EndsAt { get; set; }

        [Required(ErrorMessage = "O participante é obrigatório.")]
        [ForeignKey("Participant")]
        public string ParticipantId { get; set; }

        [DisplayName("Com")]
        public UserModel Participant { get; set; }

        [ForeignKey("Owner")]
        [JsonIgnore]
        public string OwnerId { get; set; }

        [DisplayName("Organizador")]
        public UserModel Owner { get; set; }

        [DisplayName("Link")]
        public string Link { get; set; }

        public static Dictionary<int, string> GetAvailableTypes()
        {
            return new Dictionary<int, string>(){
                {0, "Virtual" },
                {1, "Pessoal" },
            };
        }

        [JsonIgnore]
        public bool IsConfirmed => Status == AppointmentStatus.Confirmed;

        [JsonIgnore]
        public bool isDraft => Status == AppointmentStatus.Draft;

        public string TypeLabel => GetAvailableTypes()[(int)Type];

        public UserModel GetOppositeParticipant(UserModel owner)
        {
            return OwnerId == owner.Id ? Participant : Owner;
        }

        public bool CanRespondToAppointment(UserModel owner)
        {
            return ParticipantId == owner.Id && Status == AppointmentStatus.Draft;
        }

        public bool CanSeeAppointment(UserModel owner)
        {
            return owner.IsAdmin || (ParticipantId == owner.Id || OwnerId == owner.Id);
        }

        public bool CanEditAppointment(UserModel owner)
        {
            return CanSeeAppointment(owner) && IsConfirmed;
        }

        public Dictionary<string, object> Serialize()
        {
            return new Dictionary<string, object>()
            {
                {"title", Title },
                {"description", Description },
                {"type", (int)Type },
                {"startsAt", StartsAt },
                {"endsAt", EndsAt },
                {"participantId", ParticipantId },
                {"participant", Participant.Serialize() },
                {"owner", Owner.Serialize() },
            };
        }
    }
}
