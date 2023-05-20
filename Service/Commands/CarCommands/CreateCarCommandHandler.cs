using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.CarCommands;

namespace Services.Handlers.CarHandlers
{
    internal class CreateCarHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarHandler(IRepository<Car> repository)
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
                CompanyId = command.CompanyId
            };

            return await _repository.InsertAsync(car);
        }
    }
}
