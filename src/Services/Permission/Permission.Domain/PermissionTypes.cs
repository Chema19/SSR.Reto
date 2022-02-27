using System;
using System.Collections.Generic;
using System.Text;

namespace Permission.Domain
{
    public class PermissionTypes
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public Permissions Permissions { set; get; }
    }
}
