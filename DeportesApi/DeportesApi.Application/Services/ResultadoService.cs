using DeportesApi.Application.DTOs;
using DeportesApi.Application.Interfaces;
using DeportesApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Services
{
    public class ResultadoService : IResultadoService
    {

        private readonly DeportesContext _context;

        public ResultadoService(DeportesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultadoDto>> GetResultadosAsync(int pageNumber, int pageSize)
        {

            var resultados = await _context.Deportistas
               .Include(d => d.Intentos)
               .Select(d => new ResultadoDto
               {
                   Nombre = d.Nombre,
                   Pais = d.Pais,
                   Arranque = d.Intentos.Where(i => i.Modalidad == "Arranque").Max(i => (int?)i.Peso) ?? 0,
                   Envion = d.Intentos.Where(i => i.Modalidad == "Envion").Max(i => (int?)i.Peso) ?? 0
               })
               .AsNoTracking()
               .ToListAsync();

            foreach (var resultado in resultados)
            {
                resultado.Total = resultado.Arranque + resultado.Envion;
            }

            return resultados
                .OrderByDescending(r => r.Total)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

        }
    }
}
