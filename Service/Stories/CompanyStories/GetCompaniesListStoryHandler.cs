using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyStories
{
    public class GetCompaniesListStoryHandler : IRequestHandler<GetCompaniesListStory, List<Company>>
    {
        private readonly IRepository _repository;

        public GetCompaniesListStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Company>> Handle(GetCompaniesListStory story, CancellationToken cancellationToken)
        {
            var companiesList = await _repository.GetAllAsync<Company>();

            return companiesList;
        }
    }
}