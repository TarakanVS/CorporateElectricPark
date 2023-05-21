using Domain.Models;
using MediatR;

namespace Services.Commands.CompanyOwnerCommands
{
    public class GetCompaniesOwnersListCommand : IRequest<List<CompanyOwner>>
    {
    }
}
