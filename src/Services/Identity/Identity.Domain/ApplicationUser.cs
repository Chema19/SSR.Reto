using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FisrtName { set; get; }
        public string LastName { set; get; }
        public ICollection<ApplicationUserRole> UserRoles { set; get; }
    }
}
