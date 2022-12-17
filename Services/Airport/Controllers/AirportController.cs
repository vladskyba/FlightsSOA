using Airport.Models;
using Airport.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using Airport.DataTransfer;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Airport.Controllers
{
    public class AirportController : ControllerBase
    {
        public readonly IGenericRepository<AirportEntity> _airportRepository;

        private readonly IMapper _mapper;

        public AirportController(IGenericRepository<AirportEntity> airportRepository, IMapper mapper)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
        }

        [HttpPost("createAirport")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AirportReadDto))]
        public async Task<IActionResult> CreateAirport([FromBody] AirportCreateDto airportDto)
        {
            var airportModel = _mapper.Map<AirportEntity>(airportDto);

            var addedAirport = await _airportRepository.AddAsync(airportModel);
            return Ok(_mapper.Map<AirportReadDto>(addedAirport));
        }

        [HttpPut("updateAirport")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(AirportReadDto))]
        public async Task<IActionResult> UpdateAirport([Required] long airportId, [FromBody] AirportCreateDto airportDto)
        {
            var airportModel = _mapper.Map<AirportEntity>(airportDto);
            airportModel.Id = airportId;

            var addedAirport = await _airportRepository.UpdateAsync(airportModel);
            
            return Ok(_mapper.Map<AirportReadDto>(addedAirport));
        }
    }
}
