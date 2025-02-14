using DeportesApi.Application.DTOs;
using DeportesApi.Application.Interfaces;
using DeportesApi.Domain.Entities;
using DeportesApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Services
{
    public class DeportistaService : IDeportistaService
    {
        private readonly DeportesContext _context;

        public DeportistaService(DeportesContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(DeportistaDto deportistaDto)
        {
            var deportista = new Deportista
            {
                Nombre = deportistaDto.Nombre,
                Pais = deportistaDto.Pais
            };

            _context.Deportistas.Add(deportista);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
