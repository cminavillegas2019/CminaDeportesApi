using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeportesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeportesApi.Infrastructure.Persistence
{
    public class DeportesContext : DbContext
    {
        public DeportesContext(DbContextOptions<DeportesContext> options) : base(options) { }

        public DbSet<Deportista> Deportistas { get; set; }
        public DbSet<Intento> Intentos { get; set; }
        public DbSet<LogEntry> Logs { get; set; }

    }
}
