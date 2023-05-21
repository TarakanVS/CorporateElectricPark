using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.AdministratorCommands
{
    public class GetAdministratorsListCommandHandler : IRequestHandler<GetAdministratorsListCommand, List<Administrator>>
    {
        private readonly IRepository<Administrator> _repository;

        public GetAdministratorsListCommandHandler(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public async Task<List<Administrator>> Handle(GetAdministratorsListCommand command, CancellationToken cancellationToken)
        {
            var administratorsList = await _repository.GetAllAsync();

            return administratorsList;
        }
    }
}
