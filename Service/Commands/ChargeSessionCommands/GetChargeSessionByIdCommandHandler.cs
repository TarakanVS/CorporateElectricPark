using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.ChargeSessionCommands
{
    public class GetChargeSessionByIdCommandHandler : IRequestHandler<GetChargeSessionByIdCommand, ChargeSession>
    {
        private readonly IRepository<ChargeSession> _repository;

        public GetChargeSessionByIdCommandHandler(IRepository<ChargeSession> repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(GetChargeSessionByIdCommand command, CancellationToken cancellationToken)
        {
            var chargeSession = await _repository.GetByIdAsync(command.Id);

            return chargeSession;
        }
    }
}
