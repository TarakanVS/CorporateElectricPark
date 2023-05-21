using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.DriverCommands
{
    internal class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Driver>
    {
        private readonly IRepository<Driver> _repository;
        public UpdateDriverCommandHandler(IRepository<Driver> repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(UpdateDriverCommand command, CancellationToken token)
        {
            var driver = await _repository.GetByIdAsync(command.Id);

            if (driver == null)
            {
                return default;
            }

            if (command.Name != default)
            {
                driver.Name = command.Name;
            }

            if (command.PhoneNumber != default)
            {
                driver.PhoneNumber = command.PhoneNumber;
            }

            driver.EmailAddress = command.EmailAddress;

            if (command.EmailAddress != default)
            {
                driver.EmailAddress = command.EmailAddress;
            }

            driver.CompanyId = command.CompanyId;

            if (command.CompanyId != default)
            {
                driver.CompanyId = command.CompanyId;
            }

            driver.CarId = command.CarId;

            if (command.CarId != default)
            {
                driver.CarId = command.CarId;
            }

            return await _repository.UpdateAsync(driver);
        }
    }
}