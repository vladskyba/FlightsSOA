using AutoMapper;
using Flight.DataTransfer;
using Flight.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Flight.Controllers
{
    public class FlightController : ControllerBase
    {
        private readonly IGenericRepository<Models.Flight> _flightRepository;

        private readonly IMapper _mapper;

        public FlightController(IGenericRepository<Models.Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        [HttpPost("createFlight")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(FlightReadTransfer))]
        public async Task<IActionResult> CreateAirport([FromBody] FlightBaseTransfer flightDto)
        {
            var flightModel = _mapper.Map<Models.Flight>(flightDto);
            var addedFlight = await _flightRepository.AddAsync(flightModel);
            
            return Ok(_mapper.Map<FlightReadTransfer>(addedFlight));
        }
    }
}
