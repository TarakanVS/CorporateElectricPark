using Domain.Models;
using MediatR;
using Repository;

namespace Services.Commands.CompanyOwnerCommands
{
    public class GetCompanyOwnerByIdCommandHandler : IRequestHandler<GetCompanyOwnerByIdCommand, CompanyOwner>
    {
        private readonly IRepository<CompanyOwner> _repository;

        public GetCompanyOwnerByIdCommandHandler(IRepository<CompanyOwner> repository)
        {
            _repository = repository;
        }

        public async Task<CompanyOwner> Handle(GetCompanyOwnerByIdCommand command, CancellationToken cancellationToken)
        {
            var companyOwner = await _repository.GetByIdAsync(command.Id);

            return companyOwner;
        }
    }
}
