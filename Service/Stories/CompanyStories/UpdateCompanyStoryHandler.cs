using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;
using Services.Stories.CompanyStories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.CompanyStories
{
    public class UpdateCompanyStoryHandler : IRequestHandler<UpdateCompanyStory, Company>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCompanyStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(UpdateCompanyStory story, CancellationToken token)
        {
            var company = _mapper.Map(story, new Company());

            return await _repository.UpdateAsync(company);
        }
    }
}
