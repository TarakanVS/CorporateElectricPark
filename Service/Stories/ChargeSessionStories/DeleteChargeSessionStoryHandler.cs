using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    public class DeleteChargeSessionStoryHandler : IRequestHandler<DeleteChargeSessionStory, bool>
    {
        private readonly IRepository _repository;

        public DeleteChargeSessionStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteChargeSessionStory story, CancellationToken cancellationToken)
        {
            var chargeSession = await _repository.GetByIdAsync<ChargeSession>(story.Id);

            if (chargeSession == null)
                return false;

            var company = await _repository.GetByIdAsync<Company>(chargeSession.CompanyId);
            
            if (company.Debt != 0)
            {
                if (company.Debt - chargeSession.Cost > 0)
                {
                    company.Debt -= chargeSession.Cost;
                }    
                else
                {
                    company.Debt = 0;
                    company.Balance += (chargeSession.Cost - company.Debt);
                }
            }

            await _repository.UpdateAsync(company);
            await _repository.DeleteAsync<ChargeSession>(chargeSession.Id);

            return true;
        }
    }
}
