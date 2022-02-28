using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Service.EventHandlers.Commands
{
    public class PermissionCreateCommand : INotification
    {
        public string EmployeeForename { set; get; }
        public string EmployeeSurname { set; get; }
        public int PermissionType { set; get; }
        public DateTime PermissionDate { set; get; }
    }
}
