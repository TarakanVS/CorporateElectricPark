using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.AdministratorStories
{
    public class CreateAdministratorStoryHandler : IRequestHandler<CreateAdministratorStory, Administrator>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateAdministratorStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<Administrator> Handle(CreateAdministratorStory story, CancellationToken cancellationToken)
        {
            var administrator = _mapper.Map(story, new Administrator());

            return await _repository.InsertAsync(administrator);
        }
    }
}
