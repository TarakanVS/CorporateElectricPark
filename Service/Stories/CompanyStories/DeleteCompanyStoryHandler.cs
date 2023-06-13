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
    internal class DeleteCompanyStoryHandler : IRequestHandler<DeleteCompanyStory, Company>
    {
        private readonly IRepository _repository;

        public DeleteCompanyStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(DeleteCompanyStory story, CancellationToken cancellationToken)
        {
            var company = await _repository.GetByIdAsync<Company>(story.Id);
            if (company == null)
                return default;

            return await _repository.DeleteAsync<Company>(company.Id);
        }
    }
}
