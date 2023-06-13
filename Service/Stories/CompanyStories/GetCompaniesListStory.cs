using Domain.Models;
using MediatR;

namespace Services.Stories.CompanyStories
{
    public class GetCompaniesListStory : IRequest<List<Company>>
    {
    }
}
