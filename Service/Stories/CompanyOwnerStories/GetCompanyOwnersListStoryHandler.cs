using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyOwnerStories
{
    public class GetCompanyOwnersListStoryHandler : IRequestHandler<GetCompaniesOwnersListStory, List<CompanyOwner>>
    {
        private readonly IRepository _repository;

        public GetCompanyOwnersListStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyOwner>> Handle(GetCompaniesOwnersListStory story, CancellationToken cancellationToken)
        {
            var companyOwnersList = await _repository.GetAllAsync<CompanyOwner>();

            return companyOwnersList;
        }
    }
}
