using System;

namespace Permission.Domain
{
    public class Permissions
    {
        public int Id { set; get; }
        public string EmployeeForename { set; get; }
        public string EmployeeSurname { set; get; }
        public int PermissionType { set; get; }
        public DateTime PermissionDate { set; get; }
    }
}
