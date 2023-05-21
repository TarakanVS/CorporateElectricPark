using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Commands.ChargeSessionCommands
{
    public class GetChargeSessionByIdCommand : IRequest<ChargeSession>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}
