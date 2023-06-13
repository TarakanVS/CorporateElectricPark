using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CarStories
{
    public class GetCarsListStoryHandler : IRequestHandler<GetCarsListStory, List<Car>>
    {
        private readonly IRepository _repository;

        public GetCarsListStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Car>> Handle(GetCarsListStory story, CancellationToken cancellationToken)
        {
            var carsList = await _repository.GetAllAsync<Car>();

            return carsList;
        }
    }
}
