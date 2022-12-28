using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationService.DateTransfer;
using ReservationService.Enums;
using ReservationService.Models;
using ReservationService.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationService.Controllers
{
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IGenericRepository<Reservation> _reservationRepository;

        private readonly IMapper _mapper;

        public ReservationController(IGenericRepository<Reservation> flightRepository, IMapper mapper)
        {
            _reservationRepository = flightRepository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateTransfer reservationDto)
        {
            var reservationModel = _mapper.Map<Reservation>(reservationDto);
            var addedReservation = await _reservationRepository.AddAsync(reservationModel);

            return Ok(_mapper.Map<ReservationReadTransfer>(addedReservation));
        }

        [HttpPatch("updateStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> UpdateReservationStatus([Required] long reservationId, ReservationStatus reservationStatus)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            reservation.Status = reservationStatus;

            var updated = await _reservationRepository.UpdateAsync(reservation);

            return Ok(_mapper.Map<ReservationReadTransfer>(updated));
        }

        [HttpGet("getByUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> GetReservationByUser([Required] long userId)
        {
            var reservations = await _reservationRepository.GetAsync(x => x.Id == userId);
            return Ok(_mapper.Map<IEnumerable<ReservationReadTransfer>>(reservations));
        }

        [HttpGet("getByIdentitier")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> GetReservationByIdentifier([Required] long reservationId)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            return Ok(_mapper.Map<ReservationReadTransfer>(reservation));
        }

        [HttpGet("searchReservation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ReservationReadTransfer))]
        public async Task<IActionResult> SearchReservations(string? documentIdentifier, string? personName, string? personLastName, string? personSurname)
        {
            var reservation = await _reservationRepository.GetAsync(x => 
                (documentIdentifier == null || x.Tickets.Any(x => x.DocumentIdentifier == documentIdentifier)
             && (personName == null || x.Tickets.Any(x => x.PersonName == personName)
             && (personLastName == null || x.Tickets.Any(x => x.PersonLastName == personLastName)
             && (personSurname == null || x.Tickets.Any(x => x.PersonSurname == personSurname))))));

            return Ok(_mapper.Map<IEnumerable<ReservationReadTransfer>>(reservation));
        }
    }
}
