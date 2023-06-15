using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.ServiceStories
{
    public class MakeDepositStory : IRequest<Company>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [Range(0, 999999)]
        public double Amount { get; set; }
    }
}
