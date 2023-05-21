using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CarCommands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var car = new Car()
            {
                NumberPlate = command.NumberPlate,
                Model = command.Model,
                Tariff = command.Tariff,
                Mileage = command.Mileage,
                CompanyId = command.CompanyId,
                DriverId = command.DriverId
            };

            return await _repository.InsertAsync(car);
        }
    }
}
