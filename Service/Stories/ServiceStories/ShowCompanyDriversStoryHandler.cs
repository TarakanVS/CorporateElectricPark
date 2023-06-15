using Domain.Models;
using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ServiceStories
{
    public class ShowCompanyDriversStoryHandler : IRequestHandler<ShowCompanyDriversStory, List<Driver>>
    {
        private readonly IRepository _repository;

        public ShowCompanyDriversStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Driver>> Handle(ShowCompanyDriversStory story, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByPredicateAsync<Driver>(x => x.CompanyId == story.CompanyId);

            return list;
        }
    }
}
