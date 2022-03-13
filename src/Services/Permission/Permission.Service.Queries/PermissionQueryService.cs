using Microsoft.EntityFrameworkCore;
using Permission.Persistence.Database;
using Permission.Repository.Entity.IConfiguration;
using Permission.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permission.Service.Queries
{
    public interface IPermissionQueryService
    {
        Task<List<PermissionsDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<PermissionsDto> GetAsync(int id);
    }
    public class PermissionQueryService : IPermissionQueryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public PermissionQueryService(
           // ApplicationDbContext context,
            IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PermissionsDto>> GetAllAsync(int page, int take, IEnumerable<int> permissions = null)
        {
            var collection = (await _unitOfWork.Permissions.All()).Where(x => permissions == null || permissions.Contains(x.Id))
                .OrderByDescending(x => x.Id).Select(x=>new PermissionsDto { 
                    Id = x.Id,
                    EmployeeForename = x.EmployeeForename,
                    EmployeeSurname = x.EmployeeSurname,
                    PermissionType = x.PermissionType,
                    PermissionDate = x.PermissionDate
                }).ToList();
            return collection;//.MapTo<DataCollection<PermissionsDto>>();
        }

        public async Task<PermissionsDto> GetAsync(int id)
        {
            var permision = (await _unitOfWork.Permissions.GetById(id));
            var result = new PermissionsDto
            {
                Id = permision.Id,
                EmployeeForename = permision.EmployeeForename,
                EmployeeSurname = permision.EmployeeSurname,
                PermissionType = permision.PermissionType,
                PermissionDate = permision.PermissionDate
            };
            return result;
            //.SingleAsync(x => x.Id == id)).MapTo<PermissionsDto>();
            //return (await _context.Permissionss.SingleAsync(x => x.Id == id)).MapTo<PermissionsDto>();
        }
    }
}
