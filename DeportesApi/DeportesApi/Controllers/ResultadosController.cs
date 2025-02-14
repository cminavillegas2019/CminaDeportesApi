using DeportesApi.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeportesApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController : ControllerBase
    {

        private readonly IResultadoService _resultadoService;

        public ResultadosController(IResultadoService resultadoService)
        {
            _resultadoService = resultadoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResultados([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var resultados = await _resultadoService.GetResultadosAsync(pageNumber, pageSize);
            return Ok(resultados);
        }

    }
}
