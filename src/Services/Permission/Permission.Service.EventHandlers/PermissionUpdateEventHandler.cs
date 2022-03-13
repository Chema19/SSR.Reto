using MediatR;
using Microsoft.Extensions.Logging;
using Permission.Domain;
using Permission.Persistence.Database;
using Permission.Repository.Entity.IConfiguration;
using Permission.Service.EventHandlers.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Permission.Service.EventHandlers
{
    public class PermissionUpdateEventHandler : INotificationHandler<PermissionUpdateCommand>
    {
        //private readonly ApplicationDbContext _context;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PermissionUpdateEventHandler> _logger;

        //Inyectamos las dependencias
        public PermissionUpdateEventHandler(
            //ApplicationDbContext context, 
            IUnitOfWork unitOfWork
            /*ILogger<PermissionUpdateEventHandler> logger*/)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
            //_logger = logger;
        }

        public async Task Handle(PermissionUpdateCommand command, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("--- PermissionUpdateCommand started");
            //_logger.LogError("Error Description");

            var permission = new Permissions
            {
                Id = command.Id,
                EmployeeForename = command.EmployeeForename,
                EmployeeSurname = command.EmployeeSurname,
                PermissionType = command.PermissionType,
                PermissionDate = command.PermissionDate
            };

            //_logger.LogInformation("Complete Entity Permissions");
            await _unitOfWork.Permissions.Update(permission);
            //_logger.LogInformation("Update Permissions");
            await _unitOfWork.CompleteAsync();
            //_logger.LogInformation("Save Updated");
            //_logger.LogInformation("--- PermissionUpdateCommand ended");
        }
    }
}
