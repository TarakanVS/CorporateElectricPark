using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.DriverStories
{
    public class CreateDriverStoryHandler : IRequestHandler<CreateDriverStory, Driver>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateDriverStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Driver> Handle(CreateDriverStory story, CancellationToken token)
        {
            var driver = _mapper.Map(story, new Driver());

            return await _repository.InsertAsync(driver);
        }
    }
}
