using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.ServiceStories;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddChargeSessionStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] SetCarDriverStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }
    }
}
