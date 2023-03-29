using Microsoft.AspNetCore.Identity;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AdminStaffModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public IdentityRole Role { get; set; }
        public bool Status { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }

    public class AdministratorModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public int DoctorId { get; set; }
    }
}
