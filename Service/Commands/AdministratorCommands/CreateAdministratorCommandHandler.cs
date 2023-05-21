using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.AdministratorCommands;

namespace Services.Commands.AdministratorCommands
{
    public class CreateAdministratorCommandHandler : IRequestHandler<CreateAdministratorCommand, Administrator>
    {
        private readonly IRepository<Administrator> _repository;

        public CreateAdministratorCommandHandler(IRepository<Administrator> repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> Handle(CreateAdministratorCommand command, CancellationToken cancellationToken)
        {
            var administrator = new Administrator()
            {
                Name = command.Name,
                Password = command.Password,
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber
            };

            return await _repository.InsertAsync(administrator);
        }
    }
}
