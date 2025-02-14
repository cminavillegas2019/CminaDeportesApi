using DeportesApi.Domain.Entities;
using DeportesApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Interfaces
{
    public interface IIntentoService
    {
        Task<int> GetTotalIntentosAsync(int deportistaId);
        Task<List<Intento>> GetDetalleIntentosAsync(int deportistaId);
        Task<bool> AddIntentoAsync(IntentoDto intentoDto);
    }
}
