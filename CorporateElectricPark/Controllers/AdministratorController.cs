using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.AdministratorStories;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdministratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Administrator>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetList()
        {
            var story = new GetAdministratorsListStory();

            var response = await _mediator.Send(story);

            if (response.Count == 0)
            {
                return NotFound("Objects not found");
            }

            return Ok(response);
        }

        [HttpGet("{Id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Administrator))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetAdministratorByIdStory story)
        {
            var response = await _mediator.Send(story);

            if (response == null)
            {
                return NotFound("Object not found");
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateAdministratorStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateAdministratorStory story)
        {
            var response = await _mediator.Send(story);

            return Ok();
        }

        [HttpDelete("{Id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteAdministratorStory story)
        {
            var response = await _mediator.Send(story);

            if (response == null)
            {
                return NotFound("Object not found");
            }

            return Ok(response);
        }
    }
}