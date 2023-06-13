using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CarStories
{
    public class GetCarByIdStoryHandler : IRequestHandler<GetCarByIdStory, Car>
    {
        private readonly IRepository _repository;

        public GetCarByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(GetCarByIdStory story, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync<Car>(story.Id);

            return car;
        }
    }
}
