using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CarCommands
{
    public class CreateCarCommand : IRequest<Car>
    {
        [MaxLength(250, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string NumberPlate { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Model { get; set; }

        [Range(0, 999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double Tariff { get; set; }

        [Range(0, 999)]
        [Required(ErrorMessage = "Field can't be empty")]
        public double Mileage { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CompanyId { get; set; }
    }
}
