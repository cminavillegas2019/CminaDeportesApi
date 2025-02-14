using DeportesApi.Application.DTOs;
using DeportesApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeportesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeportistasController : ControllerBase
    {

        private readonly IDeportistaService _deportistaService;

        public DeportistasController(IDeportistaService deportistaService)
        {
            _deportistaService = deportistaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeportista([FromBody] DeportistaDto deportistaDto)
        {
            var success = await _deportistaService.AddAsync(deportistaDto);
            if (!success)
                return BadRequest(new ErrorDto { Codigo = 400, Mensaje = "Error al crear el deportista." });

            return CreatedAtAction(nameof(CreateDeportista), deportistaDto);
        }

    }
}
