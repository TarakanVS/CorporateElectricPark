using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Stories.CarStories;
using Services.Stories.ChargeSessionStories;
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
        [Route("api/[controller]/AddChargeSession")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddChargeSession([FromBody] AddChargeSessionStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteChargeSession")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteChargeSession([FromBody] DeleteChargeSessionStory story)
        {
            var response = await _mediator.Send(story);

            if (response == false)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut]
        [Route("api/[controller]/SetCarDriver")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetCarDriver([FromBody] SetCarDriverStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/GetCompanyCarsList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyCarsList([FromBody] ShowCompanyCarsStory story)
        {
            var response = await _mediator.Send(story);

            if (response.Count == 0)
            {
                return NotFound("Company cars not found");
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/GetCompanyDriversList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyDriversList([FromBody] ShowCompanyDriversStory story)
        {
            var response = await _mediator.Send(story);

            if (response.Count == 0)
            {
                return NotFound("Company drivers not found");
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("api/[controller]/GetCompanyChargeSessionsList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyChargeSessionsList([FromBody] ShowCompanyChargeSessionsStory story)
        {
            var response = await _mediator.Send(story);

            if (response.Count == 0)
            {
                return NotFound("Company charge sessions not found");
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("api/[controller]/MakeDeposite")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MakeDeposite([FromBody] MakeDepositStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [Route("api/[controller]/SetCarTariff")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetCarTariff([FromBody] SetCarTariffStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

        [HttpPut]
        [Route("api/[controller]/SetCompanyTariff")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Company))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SetCompanyTariff([FromBody] SetCompanyTariffStory story)
        {
            var response = await _mediator.Send(story);

            return Ok(response);
        }

       
    }
}
