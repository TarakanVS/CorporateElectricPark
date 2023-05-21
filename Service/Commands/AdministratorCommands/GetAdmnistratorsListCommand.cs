using Domain.Models;
using MediatR;

namespace Services.Commands.AdministratorCommands
{
    public class GetAdministratorsListCommand : IRequest<List<Administrator>>
    {
    }
}
