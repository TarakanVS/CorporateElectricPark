using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CarCommands
{
    public class GetCarByIdCommandHandler : IRequestHandler<GetCarByIdCommand, Car>
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(GetCarByIdCommand command, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(command.Id);

            return car;
        }
    }
}
