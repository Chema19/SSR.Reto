using Microsoft.Extensions.Logging;
using Permission.Persistence.Database;
using Permission.Repository.Entity.IConfiguration;
using Permission.Repository.Entity.IRepositories;
using Permission.Repository.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Repository.Entity.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILogger _logger;

        public IPermissionRepository Permissions { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context//,
           // ILoggerFactory loggerFactory
        )
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger("logs");
            Permissions = new PermissionRepository(_context/*, _logger*/);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
