using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.ChargeSessionCommands
{
    internal class UpdateChargeSessionCommandHandler : IRequestHandler<UpdateChargeSessionCommand, ChargeSession>
    {
        private readonly IRepository<ChargeSession> _repository;
        public UpdateChargeSessionCommandHandler(IRepository<ChargeSession> repository)
        {
            _repository = repository;
        }

        public async Task<ChargeSession> Handle(UpdateChargeSessionCommand command, CancellationToken token)
        {
            var chargeSession = await _repository.GetByIdAsync(command.Id);

            if (chargeSession == null) 
            {
                return default;
            }

            if(command.SessionNumber != default) 
            {
                chargeSession.SessionNumber = command.SessionNumber;
            }

            chargeSession.EnergySpent = command.EnergySpent;

            if (command.StartDateTime != default)
            {
                chargeSession.StartDateTime = command.StartDateTime;
                chargeSession.Duration = TimeOnly.FromTimeSpan(command.FinishDateTime.Subtract(command.StartDateTime));
            }

            if (command.FinishDateTime != default)
            {
                chargeSession.FinishDateTime = command.FinishDateTime;
                chargeSession.Duration = TimeOnly.FromTimeSpan(command.FinishDateTime.Subtract(command.StartDateTime));
            }

            chargeSession.Cost = command.Cost;

            chargeSession.Debt = command.Debt;

            if (command.CarId != default)
            {
                chargeSession.CarId = command.CarId;
            }

            if (command.DriverId != default)
            {
                chargeSession.DriverId = command.DriverId;
            }

            return await _repository.UpdateAsync(chargeSession);
        }
    }
}
