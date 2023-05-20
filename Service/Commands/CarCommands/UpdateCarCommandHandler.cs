using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CarCommands
{
    internal class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Car>
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(UpdateCarCommand command, CancellationToken token)
        {
            var car = await _repository.GetByIdAsync(command.Id);

            if (car == null) 
            {
                return default;
            }

            if(command.NumberPlate != default) 
            {
                car.NumberPlate = command.NumberPlate;
            }

            if (command.Model != default)
            {
                car.Model = command.Model;
            }

            car.Tariff = command.Tariff;

            if (command.CompanyId != default)
            {
                car.CompanyId = command.CompanyId;
            }

            return await _repository.UpdateAsync(car);
        }
    }
}
