using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyStories
{
    public class CreateCompanyStoryHandler : IRequestHandler<CreateCompanyStory, Company>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateCompanyStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(CreateCompanyStory story, CancellationToken token)
        {
            var company = _mapper.Map(story, new Company());

            return await _repository.InsertAsync(company);
        }
    }
}
