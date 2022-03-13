using Microsoft.AspNetCore.Identity;
using System;

namespace Identity.Domain
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { set; get; }
        public ApplicationUser User { set; get; }
    }
}
