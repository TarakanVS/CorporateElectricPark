using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CarStories
{
    internal class UpdateCarStoryHandler : IRequestHandler<UpdateCarStory, Car>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateCarStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Car> Handle(UpdateCarStory story, CancellationToken token)
        {
            var car = _mapper.Map(story, new Car());

            return await _repository.UpdateAsync(car);
        }
    }
}
