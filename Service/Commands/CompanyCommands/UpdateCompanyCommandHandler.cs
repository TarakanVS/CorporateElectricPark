using Domain.Models;
using MediatR;
using Repository;
using Services.Commands.CompanyCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands.CompanyCommands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Company>
    {
        private readonly IRepository<Company> _repository;
        public UpdateCompanyCommandHandler(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(UpdateCompanyCommand command, CancellationToken token)
        {
            var company = await _repository.GetByIdAsync(command.Id);

            if (company == null)
            {
                return default;
            }

            if (command.Name != default)
            {
                company.Name = command.Name;
            }

            if (command.EmailAddress != default)
            {
                company.EmailAddress = command.EmailAddress;
            }

            if (command.PhoneNumber != default)
            {
                company.PhoneNumber = command.PhoneNumber;
            }

            company.Balance = command.Balance;
            company.Tariff = command.Tariff;
            company.Debt = command.Debt;

            if (command.CompanyOwnerId != default)
            {
                company.CompanyOwnerId = command.CompanyOwnerId;
            }

            return await _repository.UpdateAsync(company);
        }
    }
}
