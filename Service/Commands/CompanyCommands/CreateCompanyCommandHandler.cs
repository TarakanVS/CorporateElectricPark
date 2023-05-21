using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.CompanyCommands;

namespace Services.Commands.CompanyCommands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Company>
    {
        private readonly IRepository<Company> _repository;

        public CreateCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = new Company()
            {
                Name = command.Name,
                EmailAddress = command.EmailAddress,
                PhoneNumber = command.PhoneNumber,
                Balance = command.Balance,
                Debt = command.Debt,
                Tariff = command.Tariff,
                CompanyOwnerId = command.CompanyOwnerId
            };

            return await _repository.InsertAsync(company);
        }
    }
}
