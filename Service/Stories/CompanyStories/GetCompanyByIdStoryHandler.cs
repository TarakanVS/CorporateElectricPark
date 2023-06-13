using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyStories
{
    public class GetCompanyByIdStoryHandler : IRequestHandler<GetCompanyByIdStory, Company>
    {
        private readonly IRepository _repository;

        public GetCompanyByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(GetCompanyByIdStory story, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync<Company>(story.Id);

            return company;
        }
    }
}
