using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Service.Queries.DTOs
{
    public class PermissionTypesDto
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public List<PermissionsDto> Permissionss { set; get; }
    }
}
