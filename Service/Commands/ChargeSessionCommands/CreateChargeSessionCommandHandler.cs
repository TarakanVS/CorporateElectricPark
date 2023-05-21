using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.ChargeSessionCommands
{
    public class CreateChargeSessionCommandHandler : IRequestHandler<CreateChargeSessionCommand, ChargeSession>
    {
        private readonly IRepository<ChargeSession> _repository;

        public CreateChargeSessionCommandHandler(IRepository<ChargeSession> repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(CreateChargeSessionCommand command, CancellationToken cancellationToken)
        {
            var chargeSession = new ChargeSession()
            {
                SessionNumber = command.SessionNumber,
                EnergySpent = command.EnergySpent,
                StartDateTime = command.StartDateTime,
                FinishDateTime = command.FinishDateTime,
                Cost = command.Cost,
                Debt = command.Debt,
                DriverId = command.DriverId,
                CarId = command.CarId
            };
            chargeSession.Duration = TimeOnly.FromTimeSpan(chargeSession.FinishDateTime.Subtract(chargeSession.StartDateTime));
            return await _repository.InsertAsync(chargeSession);
        }
    }
}
