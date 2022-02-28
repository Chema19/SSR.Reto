using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permission.Domain;
using Permission.Persistence.Database;
using Permission.Repository.Entity.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Repository.Entity.Repositories
{
    public class PermissionRepository : GenericRepository<Permissions>, IPermissionRepository
    {
        public PermissionRepository(
            ApplicationDbContext context/*,
            ILogger logger*/
        ) : base(context/*, logger*/)
        {

        }

        public override async Task<IEnumerable<Permissions>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "error", typeof(PermissionRepository));
                return new List<Permissions>();
            }
        }

        public override async Task<bool> Update(Permissions entity)
        {
            try
            {
                var existingPermission = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if (existingPermission == null)
                    return await Add(entity);

                existingPermission.EmployeeForename = entity.EmployeeForename;
                existingPermission.EmployeeSurname = entity.EmployeeSurname;
                existingPermission.PermissionType = entity.PermissionType;
                existingPermission.PermissionDate = entity.PermissionDate;

                return true;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "error", typeof(PermissionRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "error", typeof(PermissionRepository));
                return false;
            }
        }
    }
}
