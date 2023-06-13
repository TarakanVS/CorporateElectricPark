using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.AdministratorStories
{
    public class GetAdministratorByIdStorieHandler : IRequestHandler<GetAdministratorByIdStory, Administrator>
    {
        private readonly IRepository _repository;

        public GetAdministratorByIdStorieHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> Handle(GetAdministratorByIdStory story, CancellationToken cancellationToken)
        {
            var administrator = await _repository.GetByIdAsync<Administrator>(story.Id);

            return administrator;
        }
    }
}
