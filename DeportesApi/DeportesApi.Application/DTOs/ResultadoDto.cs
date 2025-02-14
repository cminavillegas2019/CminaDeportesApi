using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Application.DTOs
{
    public class ResultadoDto
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int Arranque { get; set; }
        public int Envion { get; set; }
        public int Total { get; set; }
    }
}
