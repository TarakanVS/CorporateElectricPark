using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ServiceStories
{
    public class ShowCompanyDriversStory : IRequest<List<Driver>>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CompanyId { get; set; }
    }
}
