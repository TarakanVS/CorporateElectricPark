using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.AdministratorCommands
{
    internal class UpdateAdministratorCommandHandler : IRequestHandler<UpdateAdministratorCommand, Administrator>
    {
        private readonly IRepository<Administrator> _repository;
        public UpdateAdministratorCommandHandler(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> Handle(UpdateAdministratorCommand command, CancellationToken token)
        {
            var administrator = await _repository.GetByIdAsync(command.Id);

            if (administrator == null)
            {
                return default;
            }

            if (command.Name != default)
            {
                administrator.Name = command.Name;
            }

            if (command.PhoneNumber != default)
            {
                administrator.PhoneNumber = command.PhoneNumber;
            }
           
            if (command.EmailAddress != default)
            {
                administrator.EmailAddress = command.EmailAddress;
            }

            if (command.Password != default)
            {
                administrator.Password = command.Password;
            }

            return await _repository.UpdateAsync(administrator);
        }
    }
}