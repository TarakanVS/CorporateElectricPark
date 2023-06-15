using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ServiceStories
{
    public class ShowCompanyCarsStory : IRequest<List<Car>>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CompanyId { get; set; }
    }
}
