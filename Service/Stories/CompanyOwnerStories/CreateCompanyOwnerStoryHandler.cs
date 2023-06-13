using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;
using Services.Stories.CompanyOwnerStories;

namespace Services.Stories.CompanyOwnerStories
{
    public class CreateCompanyOwnerStoryHandler : IRequestHandler<CreateCompanyOwnerStory, CompanyOwner>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateCompanyOwnerStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyOwner> Handle(CreateCompanyOwnerStory story, CancellationToken cancellationToken)
        {
            var companyOwner = _mapper.Map(story, new CompanyOwner());

            return await _repository.InsertAsync(companyOwner);
        }
    }
}
