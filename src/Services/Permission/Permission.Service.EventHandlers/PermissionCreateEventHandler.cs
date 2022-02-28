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
    public class PermissionCreateEventHandler : INotificationHandler<PermissionCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PermissionCreateEventHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PermissionCreateCommand command, CancellationToken cancellationToken)
        {

            var permission = new Permissions
            {
                EmployeeForename = command.EmployeeForename,
                EmployeeSurname = command.EmployeeSurname,
                PermissionType = command.PermissionType,
                PermissionDate = command.PermissionDate
            };
            await _unitOfWork.Permissions.Add(permission);
            await _unitOfWork.CompleteAsync();
        }
    }
}
