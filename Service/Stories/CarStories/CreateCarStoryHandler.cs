using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CarStories
{
    public class CreateCarStorieHandler : IRequestHandler<CreateCarStory, Car>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateCarStorieHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Car> Handle(CreateCarStory story, CancellationToken cancellationToken)
        {
            var car = _mapper.Map(story, new Car());

            return await _repository.InsertAsync(car);
        }
    }
}
