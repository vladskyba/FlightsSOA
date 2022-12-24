using Airport.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Airport.DataTransfer;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Airport.AsyncDataServices;
using Airport.DataTransfer.Messaging;

namespace Airport.Controllers
{
    public class AirportController : ControllerBase
    {
        private readonly IGenericRepository<Models.Airport> _airportRepository;

        private readonly IMessageBusClient _messageBusClient;

        private readonly IMapper _mapper;

        public AirportController(IGenericRepository<Models.Airport> airportRepository,
            IMessageBusClient messageBusClient,
            IMapper mapper)
        {
            _airportRepository = airportRepository;
            _messageBusClient = messageBusClient;
            _mapper = mapper;
        }

        [HttpPost("createAirport")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AirportReadTransfer))]
        public async Task<IActionResult> CreateAirport([FromBody] AirportCreateTransfer airportDto)
        {
            var airportModel = _mapper.Map<Models.Airport>(airportDto);

            var addedAirport = await _airportRepository.AddAsync(airportModel);
            var airportRepresentation = _mapper.Map<AirportReadTransfer>(addedAirport);
            var airportPublishing = _mapper.Map<AirportPublished>(airportRepresentation);
            airportPublishing.Event = "airport.pushed";

            _messageBusClient.PuslishAirport(airportPublishing);

            return Ok(airportRepresentation);
        }

        [HttpPut("updateAirport")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AirportReadTransfer))]
        public async Task<IActionResult> UpdateAirport([Required] long airportId, [FromBody] AirportCreateTransfer airportDto)
        {
            var airportModel = _mapper.Map<Models.Airport>(airportDto);
            airportModel.Id = airportId;

            var addedAirport = await _airportRepository.UpdateAsync(airportModel);
            
            return Ok(_mapper.Map<AirportReadTransfer>(addedAirport));
        }
    }
}
