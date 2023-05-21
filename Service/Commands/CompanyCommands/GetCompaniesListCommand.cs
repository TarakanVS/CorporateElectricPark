using Domain.Models;
using MediatR;

namespace Services.Commands.CompanyCommands
{
    public class GetCompaniesListCommand : IRequest<List<Company>>
    {
    }
}
