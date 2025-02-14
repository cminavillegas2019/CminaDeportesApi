using DeportesApi.Application.DTOs;
using DeportesApi.Application.Interfaces;
using DeportesApi.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeportesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IntentosController : ControllerBase
    {

        private readonly IIntentoService _intentoService;
        private readonly ILoggerService _logger;

        public IntentosController(IIntentoService intentoService, ILoggerService logger) { 
            _intentoService = intentoService;
            _logger = logger;
        }

        [HttpGet("{deportistaId}")]
        public async Task<IActionResult> GetTotalIntentosDetalle(int deportistaId)
        {
            var totalIntentos = await _intentoService.GetTotalIntentosAsync(deportistaId);
            return Ok(new { DeportistaId = deportistaId, TotalIntentos = totalIntentos });
        }

        [HttpGet("total-intentos/{deportistaId}")]
        public async Task<IActionResult> GetTotalIntentos(int deportistaId)
        {
            var intentos = await _intentoService.GetDetalleIntentosAsync(deportistaId);
            return Ok(new { DeportistaId = deportistaId, TotalIntentos = intentos.Count, Intentos = intentos });
        }

        [HttpPost]
        public async Task<IActionResult> AddIntento([FromBody] IntentoDto intentoDto)
        {
            var success = await _intentoService.AddIntentoAsync(intentoDto);
            if (!success)
            {
                _logger.Log($"Intento fallido: Deportista {intentoDto.DeportistaId} no encontrado.");
                return BadRequest(new ErrorDto { Codigo = 400, Mensaje = "El deportista no existe." });
            }

            _logger.Log($"Nuevo intento registrado para Deportista {intentoDto.DeportistaId}: {intentoDto.Modalidad} - {intentoDto.Peso}kg");
            return CreatedAtAction(nameof(GetTotalIntentos), new { deportistaId = intentoDto.DeportistaId }, intentoDto);
        }

    }
}
