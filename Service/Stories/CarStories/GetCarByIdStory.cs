using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.CarStories
{
    public class GetCarByIdStory : IRequest<Car>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
