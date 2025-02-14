using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeportesApi.Domain.Entities;

namespace DeportesApi.Application.Interfaces
{
    public interface IDeportistaRepository
    {
        Task<IEnumerable<Deportista>> GetAllAsync();
        Task<Deportista> GetByIdAsync(int id);
        Task AddAsync(Deportista deportista);
        Task UpdateAsync(Deportista deportista);
        Task DeleteAsync(int id);
    }
}
