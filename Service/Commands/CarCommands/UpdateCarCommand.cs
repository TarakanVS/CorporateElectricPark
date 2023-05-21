using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CarCommands
{
    public class UpdateCarCommand : IRequest<Car>
    {
        public UpdateCarCommand(Guid id, string? numberPlate, string? model, double mileage, double tariff, Guid driverId, Guid companyId)
        {
            Id = id;
            NumberPlate = numberPlate;
            Model = model;
            Mileage = mileage;
            Tariff = tariff;
            DriverId = driverId;
        }

        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        public string NumberPlate { get; set; }

        [MaxLength(250, ErrorMessage = "String too long!")]
        public string Model { get; set; }

        [Range(0, 999)]
        public double Tariff { get; set; }

        [Range(0, 999)]
        public double Mileage { get; set; }

        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }

    }
}
