using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.CarStories;

namespace CorporateElectricPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetList()
        {
            var story = new GetCarsListStory();

            var response = await _mediator.Send(story);

            if (response.Count == 0)
            {
                return NotFound("Objects not found");
            }

            return Ok(response);
        }

        [HttpGet("{Id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetCarByIdStory story)
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
        public async Task<IActionResult> Post([FromBody] CreateCarStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] UpdateCarStory story)
        {
            var response = await _mediator.Send(story);

            return Ok();
        }

        [HttpDelete("{Id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] DeleteCarStory story)
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
