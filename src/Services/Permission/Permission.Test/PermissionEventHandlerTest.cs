using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Permission.Domain;
using Permission.Repository.Entity.Configuration;
using Permission.Repository.Entity.IConfiguration;
using Permission.Service.EventHandlers;
using Permission.Service.EventHandlers.Commands;
using Permission.Service.Queries;
using Permission.Test.Config;
using System;
using System.Linq;
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

            var EmployeeForename = "Add Reto";
            var Employeesurname = "Test 1";
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
                EmployeeForename = "Add Reto 2",
                EmployeeSurname = "Test 1.1",
                PermissionType = 2,
                PermissionDate = Convert.ToDateTime("2022-02-27"),
            }, new CancellationToken()).Wait();
        }

        [TestMethod]
        public void GetAllByDatePermission()
        {
            var context = ApplicationDbContextInMemory.Get();//BASE DE DATOS EN MEMORIA .... NO AFECTA A LA BASE DE DATOS ORIGINAL POR QUE SE REPLICA EN MEMORIA
            var unitOfWork = new UnitOfWork(context);

            for (int i=1;i<10;i++)
            {
                context.Permissionss.Add(new Permissions
                {
                    EmployeeForename = i.ToString(),
                    EmployeeSurname = i.ToString(),
                    PermissionType = 1,
                    PermissionDate = Convert.ToDateTime("2022-02-" + i.ToString())
                });
                context.SaveChanges();
            }

            var queryService = new PermissionQueryService(unitOfWork);

            var result = queryService.GetAsync(5); 
        }

        [TestMethod]
        public void AddMultiplePermission()
        {
            var context = ApplicationDbContextInMemory.Get();//BASE DE DATOS EN MEMORIA .... NO AFECTA A LA BASE DE DATOS ORIGINAL POR QUE SE REPLICA EN MEMORIA
            var unitOfWork = new UnitOfWork(context);

            var handler = new PermissionCreateEventHandler(unitOfWork);

            handler.Handle(new PermissionCreateCommand
            {
                EmployeeForename = "Add Reto",
                EmployeeSurname = "Test 3",
                PermissionType = 2,
                PermissionDate = Convert.ToDateTime("2022-02-27"),
            }, new CancellationToken()).Wait();
        }
    }
}
