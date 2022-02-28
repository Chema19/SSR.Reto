using MediatR;
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
        public PermissionUpdateEventHandler(
            //ApplicationDbContext context, 
            IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermissionUpdateCommand command, CancellationToken cancellationToken)
        {

            var permission = new Permissions
            {
                Id = command.Id,
                EmployeeForename = command.EmployeeForename,
                EmployeeSurname = command.EmployeeSurname,
                PermissionType = command.PermissionType,
                PermissionDate = command.PermissionDate
            };
            await _unitOfWork.Permissions.Update(permission);
            await _unitOfWork.CompleteAsync();
        }
    }
}
