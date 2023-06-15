using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ServiceStories
{
    public class SetCarTariffStory : IRequest<Car>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CarId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [Range(0, 999999)]
        public double Tariff { get; set; }
    }
}
