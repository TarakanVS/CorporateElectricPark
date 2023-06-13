using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.DriverStories
{
    internal class UpdateDriverStoryHandler : IRequestHandler<UpdateDriverStory, Driver>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDriverStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Driver> Handle(UpdateDriverStory story, CancellationToken token)
        {
            var driver = _mapper.Map(story, new Driver());

            return await _repository.UpdateAsync(driver);
        }
    }
}