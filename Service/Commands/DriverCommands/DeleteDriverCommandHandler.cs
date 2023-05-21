using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.DriverCommands
{
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Driver>
    {
        private readonly IRepository<Driver> _repository;

        public DeleteDriverCommandHandler(IRepository<Driver> repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
        {
            var driver = await _repository.GetByIdAsync(command.Id);
            if (driver == null)
                return default;

            return await _repository.DeleteAsync(driver.Id);
        }
    }
}
