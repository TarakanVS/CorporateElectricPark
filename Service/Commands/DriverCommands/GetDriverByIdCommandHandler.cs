using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.DriverCommands
{
    public class GetDriverByIdCommandHandler : IRequestHandler<GetDriverByIdCommand, Driver>
    {
        private readonly IRepository<Driver> _repository;

        public GetDriverByIdCommandHandler(IRepository<Driver> repository)
        {
            _repository = repository;
        }

        public async Task<Driver> Handle(GetDriverByIdCommand command, CancellationToken cancellationToken)
        {
            var driver = await _repository.GetByIdAsync(command.Id);

            return driver;
        }
    }
}
