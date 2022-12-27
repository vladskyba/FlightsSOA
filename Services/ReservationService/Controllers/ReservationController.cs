using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.DateTransfer;
using ReservationService.Models;
using ReservationService.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ReservationService.Controllers
{
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IGenericRepository<Reservation> _flightRepository;

        private readonly IMapper _mapper;

        public ReservationController(IGenericRepository<Reservation> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        [HttpPost("createReservation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateTransfer reservationDto)
        {
            var reservationModel = _mapper.Map<Reservation>(reservationDto);
            var addedReservation = await _flightRepository.AddAsync(reservationModel);

            return Ok(_mapper.Map<ReservationReadTransfer>(addedReservation));
        }
    }
}
