using Domain.Models;
using MediatR;

namespace Services.Commands.ChargeSessionCommands
{
    public class GetChargeSessionsListCommand : IRequest<List<ChargeSession>>
    {
    }
}
