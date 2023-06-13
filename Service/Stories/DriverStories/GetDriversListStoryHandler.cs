using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.DriverStories
{
    public class GetDriversListStoryHandler : IRequestHandler<GetDriversListStory, List<Driver>>
    {
        private readonly IRepository _repository;

        public GetDriversListStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Driver>> Handle(GetDriversListStory story, CancellationToken cancellationToken)
        {
            var driversList = await _repository.GetAllAsync<Driver>();

            return driversList;
        }
    }
}
