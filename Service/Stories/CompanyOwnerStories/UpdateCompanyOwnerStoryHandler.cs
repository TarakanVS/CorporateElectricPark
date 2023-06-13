using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.CompanyOwnerStories
{
    internal class UpdateCompanyOwnerStoryHandler : IRequestHandler<UpdateCompanyOwnerStory, CompanyOwner>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCompanyOwnerStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyOwner> Handle(UpdateCompanyOwnerStory story, CancellationToken token)
        {
            var companyOwner = _mapper.Map(story, new CompanyOwner());

            return await _repository.UpdateAsync(companyOwner);
        }
    }
}