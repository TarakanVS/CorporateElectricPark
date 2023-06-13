using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    public class GetChargeSessionsListStoryHandler : IRequestHandler<GetChargeSessionsListCommand, List<ChargeSession>>
    {
        private readonly IRepository _repository;

        public GetChargeSessionsListStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChargeSession>> Handle(GetChargeSessionsListCommand story, CancellationToken cancellationToken)
        {
            var chargeSessionsList = await _repository.GetAllAsync<ChargeSession>();

            return chargeSessionsList;
        }
    }
}
