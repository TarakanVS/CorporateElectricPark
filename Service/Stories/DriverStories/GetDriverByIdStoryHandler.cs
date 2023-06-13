using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.DriverStories
{
    public class GetDriverByIdStoryHandler : IRequestHandler<GetDriverByIdStory, Driver>
    {
        private readonly IRepository _repository;

        public GetDriverByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(GetDriverByIdStory story, CancellationToken cancellationToken)
        {
            var driver = await _repository.GetByIdAsync<Driver>(story.Id);

            return driver;
        }
    }
}
