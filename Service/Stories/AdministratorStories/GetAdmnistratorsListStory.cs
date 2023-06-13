using Domain.Models;
using MediatR;

namespace Services.Stories.AdministratorStories
{
    public class GetAdministratorsListStory : IRequest<List<Administrator>>
    {
    }
}
