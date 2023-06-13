using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    public class GetChargeSessionByIdStoryHandler : IRequestHandler<GetChargeSessionByIdStory, ChargeSession>
    {
        private readonly IRepository _repository;

        public GetChargeSessionByIdStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(GetChargeSessionByIdStory story, CancellationToken cancellationToken)
        {
            var chargeSession = await _repository.GetByIdAsync<ChargeSession>(story.Id);

            return chargeSession;
        }
    }
}
