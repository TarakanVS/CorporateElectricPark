using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CarCommands
{
    public class GetCarsListCommandHandler : IRequestHandler<GetCarsListCommand, List<Car>>
    {
        private readonly IRepository<Car> _repository;

        public GetCarsListCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<Car>> Handle(GetCarsListCommand command, CancellationToken cancellationToken)
        {
            var carsList = await _repository.GetAllAsync();

            return carsList;
        }
    }
}
