using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Permission.Domain;
using Permission.Repository.Entity.Configuration;
using Permission.Repository.Entity.IConfiguration;
using Permission.Service.EventHandlers;
using Permission.Service.EventHandlers.Commands;
using Permission.Test.Config;
using System;
using System.Threading;

namespace Permission.Test
{
    [TestClass]
    public class PermissionEventHandlerTest
    {
        //private readonly IUnitOfWork _unitOfWork;
        
        [TestMethod]
        public void TryToUpdateNewPermission()
        {
            var context = ApplicationDbContextInMemory.Get();//BASE DE DATOS EN MEMORIA .... NO AFECTA A LA BASE DE DATOS ORIGINAL POR QUE SE REPLICA EN MEMORIA
            var unitOfWork = new UnitOfWork(context);

            var EmployeeForename = "Rossana Guisela";
            var Employeesurname = "Villafuerte Garcia";
            var PermissionType = 1;
            var PermissionDate = Convert.ToDateTime("2021-01-01");

            var permission = new Permissions
            {
                EmployeeForename = EmployeeForename,
                EmployeeSurname = Employeesurname,
                PermissionType = PermissionType,
                PermissionDate = PermissionDate
            };
            context.Permissionss.Add(permission);

            context.SaveChanges();

            var handler = new PermissionUpdateEventHandler(unitOfWork);

            handler.Handle(new PermissionUpdateCommand {
                Id = permission.Id,
                EmployeeForename = "Josemaria Alonso",
                EmployeeSurname = "Inga Villafuerte",
                PermissionType = 2,
                PermissionDate = Convert.ToDateTime("2022-02-27"),
            }, new CancellationToken()).Wait();
        }
    }
}
