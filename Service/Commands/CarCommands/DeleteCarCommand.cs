using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.CarCommands
{
    public class DeleteCarCommand : IRequest<Car>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
