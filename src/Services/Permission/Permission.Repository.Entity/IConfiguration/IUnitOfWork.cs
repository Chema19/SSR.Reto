using Permission.Repository.Entity.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Permission.Repository.Entity.IConfiguration
{
    public interface IUnitOfWork
    {
        IPermissionRepository Permissions { get; }
        Task CompleteAsync();
    }
}
