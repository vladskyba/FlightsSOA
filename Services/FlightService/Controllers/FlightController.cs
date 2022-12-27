using AutoMapper;
using FlightService.AsyncDataServices;
using FlightService.DataTransfer;
using FlightService.Models;
using FlightService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Controllers
{
    public class FlightController : ControllerBase
    {
        private readonly IGenericRepository<Flight> _flightRepository;

        private readonly IMessageBusClient _messageBusClient;

        private readonly IMapper _mapper;

        public FlightController(IGenericRepository<Flight> flightRepository, IMessageBusClient messageBusClient, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _messageBusClient = messageBusClient;
            _mapper = mapper;
        }

        [HttpPost("createFlight")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(FlightReadTransfer))]
        public async Task<IActionResult> CreateFlight([FromBody] FlightBaseTransfer flightDto)
        {
            var flightModel = _mapper.Map<Flight>(flightDto);
            var addedFlight = await _flightRepository.AddAsync(flightModel);
            var retrievedFlight = await _flightRepository.GetAsync(x => x.Id == addedFlight.Id, 
                i => i.Include(p => p.DepartureAirport)
                    .ThenInclude(i => i.AirportAddress)
                    .Include(p => p.ArrivalAirport)
                    .ThenInclude(a => a.AirportAddress));
            var readFlight = _mapper.Map<FlightReadTransfer>(retrievedFlight.SingleOrDefault());
            _messageBusClient.PushMessage(readFlight, "flight.created");

            return Ok(readFlight);
        }
    }
}
