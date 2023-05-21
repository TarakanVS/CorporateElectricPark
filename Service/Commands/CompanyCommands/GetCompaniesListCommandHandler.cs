using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyCommands
{
    public class GetCompaniesListCommandHandler : IRequestHandler<GetCompaniesListCommand, List<Company>>
    {
        private readonly IRepository<Company> _repository;

        public GetCompaniesListCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<List<Company>> Handle(GetCompaniesListCommand command, CancellationToken cancellationToken)
        {
            var companiesList = await _repository.GetAllAsync();

            return companiesList;
        }
    }
}