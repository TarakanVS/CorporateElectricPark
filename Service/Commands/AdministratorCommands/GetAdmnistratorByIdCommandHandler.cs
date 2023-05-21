using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.AdministratorCommands
{
    public class GetAdministratorByIdCommandHandler : IRequestHandler<GetAdministratorByIdCommand, Administrator>
    {
        private readonly IRepository<Administrator> _repository;

        public GetAdministratorByIdCommandHandler(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> Handle(GetAdministratorByIdCommand command, CancellationToken cancellationToken)
        {
            var administrator = await _repository.GetByIdAsync(command.Id);

            return administrator;
        }
    }
}
