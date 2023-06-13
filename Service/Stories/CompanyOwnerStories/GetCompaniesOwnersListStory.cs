using Domain.Models;
using MediatR;

namespace Services.Stories.CompanyOwnerStories
{
    public class GetCompaniesOwnersListStory : IRequest<List<CompanyOwner>>
    {
    }
}
