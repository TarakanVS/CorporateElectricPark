using AutoMapper;
using Domain.Models;
using MediatR;
using Repository;

namespace Services.Stories.ChargeSessionStories
{
    internal class UpdateChargeSessionCommandHandler : IRequestHandler<UpdateChargeSessionStory, ChargeSession>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateChargeSessionCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ChargeSession> Handle(UpdateChargeSessionStory story, CancellationToken token)
        {
            var chargeSession = _mapper.Map(story, new ChargeSession());
            return await _repository.UpdateAsync(chargeSession);
        }
    }
}
