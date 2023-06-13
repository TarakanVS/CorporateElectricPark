using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.AdministratorStories
{
    public class GetAdministratorsListStorieHandler : IRequestHandler<GetAdministratorsListStory, List<Administrator>>
    {
        private readonly IRepository _repository;

        public GetAdministratorsListStorieHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Administrator>> Handle(GetAdministratorsListStory story, CancellationToken cancellationToken)
        {
            var administratorsList = await _repository.GetAllAsync<Administrator>();

            return administratorsList;
        }
    }
}
