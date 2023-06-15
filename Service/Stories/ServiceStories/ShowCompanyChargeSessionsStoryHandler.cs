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
    public class ShowCompanyChargeSessionsStoryHandler : IRequestHandler<ShowCompanyChargeSessionsStory, List<ChargeSession>>
    {
        private readonly IRepository _repository;

        public ShowCompanyChargeSessionsStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChargeSession>> Handle(ShowCompanyChargeSessionsStory story, CancellationToken cancellationToken)
        {
            var list = await _repository.GetByPredicateAsync<ChargeSession>(x => x.CompanyId == story.CompanyId);

            return list;
        }
    }
}
