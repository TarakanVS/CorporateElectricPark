using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.AdministratorStories
{
    internal class UpdateAdministratorStoryHandler : IRequestHandler<UpdateAdministratorStory, Administrator>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateAdministratorStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Administrator> Handle(UpdateAdministratorStory story, CancellationToken token)
        {
            var administrator = _mapper.Map(story, new Administrator());

            return await _repository.UpdateAsync(administrator);
        }
    }
}