using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyOwnerStories
{
    public class GetCompanyOwnerByIdStoryHandler : IRequestHandler<GetCompanyOwnerByIdStory, CompanyOwner>
    {
        private readonly IRepository _repository;

        public GetCompanyOwnerByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(GetCompanyOwnerByIdStory story, CancellationToken cancellationToken)
        {
            var companyOwner = await _repository.GetByIdAsync<CompanyOwner>(story.Id);

            return companyOwner;
        }
    }
}
