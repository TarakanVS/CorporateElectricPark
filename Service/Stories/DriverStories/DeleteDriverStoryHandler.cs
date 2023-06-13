using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.DriverStories
{
    public class DeleteDriverStoryHandler : IRequestHandler<DeleteDriverStory, Driver>
    {
        private readonly IRepository _repository;

        public DeleteDriverStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(DeleteDriverStory story, CancellationToken cancellationToken)
        {
            var driver = await _repository.GetByIdAsync<Driver>(story.Id);
            if (driver == null)
                return default;

            return await _repository.DeleteAsync<Driver>(driver.Id);
        }
    }
}
