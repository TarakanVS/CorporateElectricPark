using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ChargeSessionStories
{
    public class CreateChargeSessionStory : IRequest<ChargeSession>
    {
        [MaxLength(25, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string SessionNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Field can't be empty")]
        public DateTime FinishDateTime { get; set; }

        [Range(0, 999999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double EnergySpent { get; set; }

        [Range(0, 999999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double Cost { get; set; }

        [Range(0, 999999)]
        public double Debt { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CarId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public Guid DriverId { get; set; }
    }
}
