using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CarCommands
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Car>
    {
        private readonly IRepository<Car> _repository;

        public DeleteCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            if (car == null)
                return default;

            return await _repository.DeleteAsync(car.Id);
        }
    }
    {
    }
}
