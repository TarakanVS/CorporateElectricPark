using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.ChargeSessionCommands
{
    public class GetChargeSessionsListCommandHandler : IRequestHandler<GetChargeSessionsListCommand, List<ChargeSession>>
    {
        private readonly IRepository<ChargeSession> _repository;

        public GetChargeSessionsListCommandHandler(IRepository<ChargeSession> repository)
        {
            _repository = repository;
        }

        public async Task<List<ChargeSession>> Handle(GetChargeSessionsListCommand command, CancellationToken cancellationToken)
        {
            var chargeSessionsList = await _repository.GetAllAsync();

            return chargeSessionsList;
        }
    }
}
