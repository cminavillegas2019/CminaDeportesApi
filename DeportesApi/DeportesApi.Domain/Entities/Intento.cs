using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Domain.Entities
{
    public class Intento
    {
        public int Id { get; set; }
        public int DeportistaId { get; set; }
        public string Modalidad { get; set; } // "Arranque" o "Envion"
        public int Peso { get; set; }
        public Deportista Deportista { get; set; }
    }
}
