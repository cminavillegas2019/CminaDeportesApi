using DeportesApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.Interfaces
{
    public interface IDeportistaService
    {
        Task<bool> AddAsync(DeportistaDto deportistaDto);
    }
}
