using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Services.Stories.CompanyOwnerStories
{
    public class DeleteCompanyOwnerStory : IRequest<CompanyOwner>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid Id { get; set; }
    }
}

