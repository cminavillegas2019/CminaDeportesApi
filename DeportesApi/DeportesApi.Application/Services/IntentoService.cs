using DeportesApi.Application.DTOs;
using DeportesApi.Application.Interfaces;
using DeportesApi.Domain.Entities;
using DeportesApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Services
{
    public class IntentoService : IIntentoService
    {

        private readonly DeportesContext _context;

        public IntentoService(DeportesContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalIntentosAsync(int deportistaId)
        {
            return await _context.Intentos.CountAsync(i => i.DeportistaId == deportistaId);
        }

        public async Task<List<Intento>> GetDetalleIntentosAsync(int deportistaId)
        {
            return await _context.Intentos.Where(i => i.DeportistaId == deportistaId).ToListAsync();
        }

        public async Task<bool> AddIntentoAsync(IntentoDto intentoDto)
        {
            var deportista = await _context.Deportistas.FindAsync(intentoDto.DeportistaId);
            if (deportista == null)
                return false;

            var intento = new Intento
            {
                DeportistaId = intentoDto.DeportistaId,
                Modalidad = intentoDto.Modalidad,
                Peso = intentoDto.Peso
            };

            _context.Intentos.Add(intento);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
