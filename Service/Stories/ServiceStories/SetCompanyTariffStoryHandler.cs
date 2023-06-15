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
    public class SetCompanyTariffStoryHandler : IRequestHandler<SetCompanyTariffStory, Company>
    {
        private readonly IRepository _repository;

        public SetCompanyTariffStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(SetCompanyTariffStory story, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync<Company>(story.CompanyId);

            entity.Tariff = story.Tariff;

            var updated = await _repository.UpdateAsync<Company>(entity);

            return updated;
        }
    }
}
