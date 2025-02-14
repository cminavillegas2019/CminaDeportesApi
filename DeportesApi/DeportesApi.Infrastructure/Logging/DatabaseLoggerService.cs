using DeportesApi.Domain.Entities;
using DeportesApi.Infrastructure.Interfaces;
using DeportesApi.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeportesApi.Infrastructure.Logging
{
    public class DatabaseLoggerService : ILoggerService
    {
        private readonly DeportesContext _context;

        public DatabaseLoggerService(DeportesContext context)
        {
            _context = context;
        }

        public void Log(string message)
        {
            var logEntry = new LogEntry { Message = message };
            _context.Logs.Add(logEntry);
            _context.SaveChanges();
        }
    }
}
