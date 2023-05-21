using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.DriverCommands
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Driver>
    {
        private readonly IRepository<Driver> _repository;

        public CreateDriverCommandHandler(IRepository<Driver> repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
        {
            var driver = new Driver()
            {
                Name = command.Name,
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber,
                CarId = command.CarId,
                CompanyId = command.CompanyId
            };

            return await _repository.InsertAsync(driver);
        }
    }
}
