using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.DTOs
{
    public class IntentoDto
    {
        public int DeportistaId { get; set; }
        public string Modalidad { get; set; } // "Arranque" o "Envion"
        public int Peso { get; set; }
    }
}
