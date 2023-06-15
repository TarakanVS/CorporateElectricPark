using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ServiceStories
{
    public class MakeDepositStoryHandler : IRequestHandler<MakeDepositStory, Company>
    {
        private readonly IRepository _repository;

        public MakeDepositStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(MakeDepositStory story, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync<Company>(story.CompanyId);

            if (entity.Debt != 0)
            {
                if (entity.Debt - story.Amount > 0)
                {
                    entity.Debt -= story.Amount;
                }
                else
                {
                    entity.Debt = 0;
                    entity.Balance += story.Amount;
                }
            }
            else
            {
                entity.Balance += story.Amount;
            }

            var updated = await _repository.UpdateAsync(entity);

            return updated;
        }
    }
}
