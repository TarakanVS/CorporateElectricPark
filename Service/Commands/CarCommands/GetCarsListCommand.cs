using Domain.Models;
using MediatR;

namespace Services.Commands.CarCommands
{
    public class GetCarsListCommand : IRequest<List<Car>>
    {
    }
}
