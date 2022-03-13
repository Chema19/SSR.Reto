using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Identity.Service.EventHandlers.Commands
{
    public class UserCreateCommand : IRequest<IdentityResult>
    {
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required, EmailAddress]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
