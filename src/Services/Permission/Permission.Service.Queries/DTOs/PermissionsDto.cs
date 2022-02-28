using System;

namespace Permission.Service.Queries.DTOs
{
    public class PermissionsDto
    {
        public int Id { set; get; }
        public string EmployeeForename { set; get; }
        public string EmployeeSurname { set; get; }
        public int PermissionType { set; get; }
        public PermissionTypesDto PermissionTypes { set; get; }
        public DateTime PermissionDate { set; get; }
    }
}
