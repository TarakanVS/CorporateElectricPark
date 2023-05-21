using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.AdministratorCommands
{
    public class DeleteAdministratorCommandHandler : IRequestHandler<DeleteAdministratorCommand, Administrator>
    {
        private readonly IRepository<Administrator> _repository;

        public DeleteAdministratorCommandHandler(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> Handle(DeleteAdministratorCommand command, CancellationToken cancellationToken)
        {
            var administrator = await _repository.GetByIdAsync(command.Id);
            if (administrator == null)
                return default;

            return await _repository.DeleteAsync(administrator.Id);
        }
    }
}
