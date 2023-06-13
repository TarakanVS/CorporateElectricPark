using Domain.Models;
using MediatR;

namespace Services.Stories.ChargeSessionStories
{
    public class GetChargeSessionsListCommand : IRequest<List<ChargeSession>>
    {
    }
}
