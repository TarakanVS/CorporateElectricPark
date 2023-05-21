using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.DriverCommands
{
    public class GetDriversListCommandHandler : IRequestHandler<GetDriversListCommand, List<Driver>>
    {
        private readonly IRepository<Driver> _repository;

        public GetDriversListCommandHandler(IRepository<Driver> repository)
        {
            _repository = repository;
        }

        public async Task<List<Driver>> Handle(GetDriversListCommand command, CancellationToken cancellationToken)
        {
            var driversList = await _repository.GetAllAsync();

            return driversList;
        }
    }
}
