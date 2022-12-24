using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Airplane.Repositories;
using Airplane.Models;
using Airplane.DataTransfer;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Airplane.Controllers
{
    public class PlaneController : ControllerBase
    {
        public readonly IGenericRepository<Plane> _planeRepository;

        public readonly IGenericRepository<PlaneSeat> _planeSeatRepository;

        private readonly IMapper _mapper;

        public PlaneController(IGenericRepository<Plane> airportRepository, IGenericRepository<PlaneSeat> planeSeatRepository, IMapper mapper)
        {
            _planeRepository = airportRepository;
            _planeSeatRepository = planeSeatRepository;
            _mapper = mapper;
        }

        [HttpPost("createPlane")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(PlaneReadTransfer))]
        public async Task<IActionResult> CreatePlane([FromBody] PlaneBaseTransfer planeDto)
        {
            var planeModel = _mapper.Map<Plane>(planeDto);

            var addedPlane = await _planeRepository.AddAsync(planeModel);
            return Ok(_mapper.Map<PlaneReadTransfer>(addedPlane));
        }

        [HttpPut("updatePlane")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(PlaneReadTransfer))]
        public async Task<IActionResult> UpdatePlane([Required] long planeId, [FromBody] PlaneBaseTransfer planeDto)
        {
            var planeModel = _mapper.Map<Plane>(planeDto);
            planeModel.Id = planeId;

            var updatedPlane = await _planeRepository.UpdateAsync(planeModel);

            return Ok(_mapper.Map<PlaneReadTransfer>(updatedPlane));
        }

        [HttpPost("associateSeat")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(PlaneReadTransfer))]
        public async Task<IActionResult> AssociateSeat([Required] long planeId, [FromBody] PlaneSeatBaseTransfer planeSeatDto)
        {
            var planeSeatModel = _mapper.Map<PlaneSeat>(planeSeatDto);
            planeSeatModel.PlaneId = planeId;

            var createdPlaneSeat = await _planeSeatRepository.AddAsync(planeSeatModel);

            return Ok(_mapper.Map<PlaneSeatReadTransfer>(createdPlaneSeat));
        }

        [HttpGet("getPlanes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(PlaneReadTransfer))]
        public async Task<IActionResult> GetPlanes()
        {
            var planes = await _planeRepository.GetAsync(null, i => i.Include(p => p.Seats));

            return Ok(_mapper.Map<IEnumerable<PlaneReadTransfer>>(planes));
        }
    }
}
