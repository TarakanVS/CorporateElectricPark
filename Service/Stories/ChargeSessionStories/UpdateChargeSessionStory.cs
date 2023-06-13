using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ChargeSessionStories
{
    public class UpdateChargeSessionStory : IRequest<ChargeSession>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }

        [MaxLength(25, ErrorMessage = "String too long!")]
        public string SessionNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FinishDateTime { get; set; }

        [Range(0, 999999)]
        public double EnergySpent { get; set; }

        [Range(0, 999999)]
        public double Cost { get; set; }

        [Range(0, 999999)]
        public double Debt { get; set; }

        public Guid CarId { get; set; }

        public Guid DriverId { get; set; }

    }
}
