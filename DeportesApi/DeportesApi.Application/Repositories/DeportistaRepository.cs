using DeportesApi.Application.Interfaces;
using DeportesApi.Domain.Entities;
using DeportesApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Repositories
{
    public class DeportistaRepository : IDeportistaRepository
    {
        private readonly DeportesContext _context;

        public DeportistaRepository(DeportesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Deportista>> GetAllAsync()
        {
            return await _context.Deportistas.Include(d => d.Intentos).AsNoTracking().ToListAsync();
        }

        public async Task<Deportista?> GetByIdAsync(int id)
        {
            return await _context.Deportistas.Include(d => d.Intentos).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Deportista deportista)
        {
            await _context.Deportistas.AddAsync(deportista);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Deportista deportista)
        {
            _context.Deportistas.Update(deportista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deportista = await _context.Deportistas.FindAsync(id);
            if (deportista != null)
            {
                _context.Deportistas.Remove(deportista);
                await _context.SaveChangesAsync();
            }
        }
    }
}
