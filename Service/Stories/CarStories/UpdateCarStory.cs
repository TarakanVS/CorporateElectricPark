using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.CarStories
{
    public class UpdateCarStory : IRequest<Car>
    {
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
