using Domain.Models;
using MediatR;

namespace Services.Commands.DriverCommands
{
    public class GetDriversListCommand : IRequest<List<Driver>>
    {
    }
}
