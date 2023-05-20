using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Commands.CarCommands
{
    public class CreateCarCommand : IRequest<Car>
    {
        [MaxLength(250)]
        [Required]
        public string NumberPlate { get; set; }

        [MaxLength(250)]
        [Required]
        public string Model { get; set; }

        [Range(0, 999)]
        [Required]
        public double Tariff { get; set; }

        [Range(0, 999)]
        [Required]
        public double Mileage { get; set; }

        [MaxLength(250)]
        [Required]
        public Guid CompanyId { get; set; }
    }
}
