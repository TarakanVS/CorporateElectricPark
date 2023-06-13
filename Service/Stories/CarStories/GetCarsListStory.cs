using Domain.Models;
using MediatR;

namespace Services.Stories.CarStories
{
    public class GetCarsListStory : IRequest<List<Car>>
    {
    }
}
