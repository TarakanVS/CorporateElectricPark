using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.AdministratorStories
{
    public class DeleteAdministratorStory : IRequest<Administrator>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}

