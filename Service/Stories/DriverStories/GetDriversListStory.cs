using Domain.Models;
using MediatR;

namespace Services.Stories.DriverStories
{
    public class GetDriversListStory : IRequest<List<Driver>>
    {
    }
}
