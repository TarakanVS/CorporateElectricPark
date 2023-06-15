using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Stories.ServiceStories
{
    public class SetCompanyTariffStory : IRequest<Company>
    {
        [Required(ErrorMessage = "Field can't be empty")]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [Range(0, 999999)]
        public double Tariff { get; set; }
    }
}
