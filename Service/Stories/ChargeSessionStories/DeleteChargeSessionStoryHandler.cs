using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    public class DeleteChargeSessionStoryHandler : IRequestHandler<DeleteChargeSessionStory, ChargeSession>
    {
        private readonly IRepository _repository;

        public DeleteChargeSessionStoryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(DeleteChargeSessionStory story, CancellationToken cancellationToken)
        {
            var chargeSession = await _repository.GetByIdAsync<ChargeSession>(story.Id);
            if (chargeSession == null)
                return default;

            return await _repository.DeleteAsync<ChargeSession>(chargeSession.Id);
        }
    }
}
