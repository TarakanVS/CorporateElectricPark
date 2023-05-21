using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.ChargeSessionCommands
{
    public class DeleteChargeSessionCommandHandler : IRequestHandler<DeleteChargeSessionCommand, ChargeSession>
    {
        private readonly IRepository<ChargeSession> _repository;

        public DeleteChargeSessionCommandHandler(IRepository<ChargeSession> repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(DeleteChargeSessionCommand command, CancellationToken cancellationToken)
        {
            var chargeSession = await _repository.GetByIdAsync(command.Id);
            if (chargeSession == null)
                return default;

            return await _repository.DeleteAsync(chargeSession.Id);
        }
    }
}
