using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CarStories
{
    public class DeleteCarStoryHandler : IRequestHandler<DeleteCarStory, Car>
    {
        private readonly IRepository _repository;

        public DeleteCarStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(DeleteCarStory story, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync<Car>(story.Id);
            if (car == null)
                return default;

            return await _repository.DeleteAsync<Car>(car.Id);
        }
    }
}
