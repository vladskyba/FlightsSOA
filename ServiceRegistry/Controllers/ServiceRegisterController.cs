using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesRegistry.Models;
using ServicesRegistry.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace ServicesRegistry.Controllers
{
    public class ServiceRegisterController : ControllerBase
    {
        private readonly IGenericRepository<ServiceSettings> _serviceRepository;

        public ServiceRegisterController(IGenericRepository<ServiceSettings> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet("getServices")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ServiceSettings))]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceRepository.GetAsync();

            return Ok(services);
        }
    }
}
