using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyOwnerStories
{
    public class DeleteCompanyOwnerStoryHandler : IRequestHandler<DeleteCompanyOwnerStory, CompanyOwner>
    {
        private readonly IRepository _repository;

        public DeleteCompanyOwnerStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(DeleteCompanyOwnerStory story, CancellationToken cancellationToken)
        {
            var companyOwner = await _repository.GetByIdAsync<CompanyOwner>(story.Id);
            if (companyOwner == null)
                return default;

            return await _repository.DeleteAsync<CompanyOwner>(companyOwner.Id);
        }
    }
}
