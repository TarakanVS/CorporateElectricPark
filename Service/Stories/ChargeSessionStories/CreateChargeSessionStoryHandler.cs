using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    public class CreateChargeSessionStoryHandler : IRequestHandler<CreateChargeSessionStory, ChargeSession>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateChargeSessionStoryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;  
        }

        public async Task<ChargeSession> Handle(CreateChargeSessionStory story, CancellationToken cancellationToken)
        {
            var chargeSession = _mapper.Map(story, new ChargeSession());
            chargeSession.Duration = TimeOnly.FromTimeSpan(chargeSession.FinishDateTime.Subtract(chargeSession.StartDateTime));
            return await _repository.InsertAsync(chargeSession);
        }
    }
}
