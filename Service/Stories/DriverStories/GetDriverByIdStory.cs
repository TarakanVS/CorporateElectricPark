using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.DriverStories
{
    public class GetDriverByIdStory : IRequest<Driver>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
