using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyOwnerCommands
{
    public class GetCompanyOwnersListCommandHandler : IRequestHandler<GetCompaniesOwnersListCommand, List<CompanyOwner>>
    {
        private readonly IRepository<CompanyOwner> _repository;

        public GetCompanyOwnersListCommandHandler(IRepository<CompanyOwner> repository)
        {
            _repository = repository;
        }

        public async Task<List<CompanyOwner>> Handle(GetCompaniesOwnersListCommand command, CancellationToken cancellationToken)
        {
            var companyOwnersList = await _repository.GetAllAsync();

            return companyOwnersList;
        }
    }
}
