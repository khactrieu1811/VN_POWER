using Model.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UserModeAdd
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string PasswordNew { get; set; } = string.Empty;
    }

    public class UserModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; } 
        public string Gender { get; set; } 
        public string CompanyID { get; set; } 
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public JsonWebToken Token { get; set; }
        public List<NavigationMenuViewModel> Menus { get; set; }

    }
    public class ChangePasswordModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }

    public class ProfileModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string FullAdress { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
    
        public DateTime BirthDay { get; set; }
        
    }
}
