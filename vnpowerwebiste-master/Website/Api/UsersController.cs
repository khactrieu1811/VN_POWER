using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.IRepostitory;
using Common;
using Entities.Entities;
using Model;
using Website.Models;
using Website.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UsersController> _logger;
        private readonly ITokenService _tokenService;
        private readonly IDataAccessService _dataAccessService;
        private readonly IUserRepository _userRepository;
        public UsersController(SignInManager<ApplicationUser> signInManager,
           ILogger<UsersController> logger,
           UserManager<ApplicationUser> userManager, ITokenService tokenService, IDataAccessService dataAccessService, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _logger = logger;
            _dataAccessService = dataAccessService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        // To do
                        var token = _tokenService.GenerateAccessToken(user, 0, _userManager);
                        var userModel = new UserModel()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Phone = user.PhoneNumber.IfNull(),
                            Token = new JsonWebToken()
                            {
                                AccessToken = token,

                            }
                        };
                        var claimsPrincipal = _tokenService.GetPrincipalFromExpiredToken(token);
                        var roleId = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;
                        if (!string.IsNullOrEmpty(roleId))
                        {
                            userModel.Menus = await _dataAccessService.GetPermissionsByRoleIdAsync(roleId);

                        }
                        return Ok(userModel);
                    }
                    else
                    {
                        return BadRequest(new { message = MessageUserConstants.PasswordIncorrect });
                    }

                }
                else
                {
                    return BadRequest(new { message = MessageUserConstants.UserNameIncorrect });
                }

            }
            return BadRequest(new { message = MessageUserConstants.BadRequest });


        }

        [HttpPost("InsertOrUpdate")]
        public async Task<IActionResult> InsertOrUpdate([FromBody]UserModeAdd model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var Checkuser = await _userManager.FindByNameAsync(model.UserName);
                    if (string.IsNullOrEmpty(model.Id))
                    {
                        if (Checkuser == null)
                        {
                            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, FullName = model.FullName };
                            var result = await _userManager.CreateAsync(user, model.Password);
                            if (result.Succeeded)
                            {
                                var data = _userRepository.GetAll().ToList();
                                var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                                return Ok(new { message = "Thành công.", data = list });
                            }
                        }
                        else
                        {
                            var data = _userRepository.GetAll().ToList();
                            var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                            return BadRequest(new { message = "Tài khoản đã được sử dụng.", data = list });
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(model.PasswordNew))
                        {
                            var Upduser = _userRepository.GetDatabyFiler(x => x.Id == model.Id).FirstOrDefault();
                            if (Upduser == null)
                            {
                                return BadRequest(string.Format(MessageConstants.Exists, "Dữ liệu"));
                            }
                            var changePasswordResult = await _userManager.ChangePasswordAsync(Upduser, model.Password, model.PasswordNew);
                            if (changePasswordResult.Succeeded)
                            {
                                Upduser.FullName = model.FullName;
                                Upduser.Email = model.Email;
                                var rs = await this._userManager.UpdateAsync(Upduser);
                                if (rs.Succeeded)
                                {
                                    var data = _userRepository.GetAll().ToList();
                                    var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                                    return Ok(new { message = MessageConstants.Success, data = list });
                                }
                                else
                                {
                                    var PasswordResult = await _userManager.ChangePasswordAsync(Upduser, model.PasswordNew, model.Password);
                                    if (PasswordResult.Succeeded)
                                    {
                                        var data = _userRepository.GetAll().ToList();
                                        var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                                        return BadRequest(new { message = "Có lỗi xảy ra.", data = list });
                                    }
                                    else
                                    {
                                        var data = _userRepository.GetAll().ToList();
                                        var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                                        return BadRequest(new { message = "Có lỗi xảy ra.", data = list });
                                    }

                                }
                            }
                            else
                            {
                                var data = _userRepository.GetAll().ToList();
                                var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                                return BadRequest(new { message = "Có lỗi xảy ra.", data = list });
                            }
                        }
                        else
                        {

                        }

                    }


                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    return BadRequest(new { message = "Có lỗi xảy ra." });
                }
            }

            return BadRequest(new { message = MessageConstants.BadRequest });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _userRepository.GetAll().ToList();
                var rs = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                return Ok(rs);
            }
            catch (Exception ex)
            {

            }

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = this._userRepository.GetByFiler(x => x.Id == id).FirstOrDefault();
                    var rs = await _userManager.DeleteAsync(role);
                    if (rs.Succeeded)
                    {
                        var data = _userRepository.GetAll().ToList();
                        var list = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                        return Ok(list);
                    }
                    else
                    {
                        return BadRequest(new { message = "Lỗi delete dữ liệu." });
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    return BadRequest(new { message = "Có lỗi xảy ra." });
                }
            }
            return BadRequest(new { message = MessageConstants.BadRequest });
        }

        [HttpGet("GetFitterByName")]
        public IActionResult GetFitterByName(string name)
        {
            try
            {
                var data = _userRepository.GetAll().Where(x => x.FullName.ToUpper().Contains(name.ToUpper()) || x.UserName.ToUpper().Contains(name.ToUpper()) || x.Email.ToUpper().Contains(name.ToUpper())).ToList();
                var rs = data.Select(x => new { x.Id, x.FullName, x.UserName, x.PasswordHash, x.Email });
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return Ok();


        }


        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var rs = new ResultObject<int>()
            {
                Status = false
            };
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var check = await _userManager.CheckPasswordAsync(user, model.OldPassword);
                    if (check)
                    {
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                        rs.Status = true;
                        rs.Message = string.Format(MessageConstants.Success, "Đổi password");
                        return Ok(rs);
                    }
                    rs.Message = "Mật khẩu cũ không đúng";
                    return Ok(rs);
                }
                rs.Message = string.Format(MessageConstants.NotExists, "Tài khoản");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                rs.Message = MessageConstants.Error;
            }
            return Ok(rs);


        }

        [HttpGet("MyProfile")]
        public async Task<IActionResult> MyProfile()
        {
            try
            {

                string userId = User.FindFirst(ClaimTypes.Name)?.Value;

                var user = await _userManager.FindByIdAsync(userId);
                if(user != null)
                {
                    return Ok(new { 
                        user.Id,user.FullName, user.FullAddress, user.Avatar, 
                        user.Email, user.PhoneNumber,user.Sex,user.BirthDay
                    });
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return Ok();


        }

        [HttpPost("MyProfile")]
        public async Task<IActionResult> MyProfile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    string userId = User.FindFirst(ClaimTypes.Name)?.Value;

                    var user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        user.BirthDay = model.BirthDay;
                        user.FullName = model.FullName;
                        user.FullAddress = model.FullAdress;
                        user.PhoneNumber = model.PhoneNumber;
                        user.Sex = model.Sex;
                        await _userManager.UpdateAsync(user);
                        return Ok(new ResponseModel<int> { Message = string.Format(MessageConstants.Success, "Cập nhật Thông tin"), Success = true });
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return Ok(new ResponseModel<int> { Message = MessageConstants.Error, Success = false });
                }

            }
            return BadRequest(new { message = MessageConstants.BadRequest });
        }

        [HttpPost("UploadAvatar")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            if(file == null) return BadRequest(new { message = MessageConstants.BadRequest });

            try
            {
                string userId = User.FindFirst(ClaimTypes.Name)?.Value;
                string folder = $"UploadFiles/Images/ProfileUser/{DateTime.Now:yyyyMM}/{userId}";
                // full path to file in temp location
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    folder);

                bool folderExists = Directory.Exists(filePath);
                if (!folderExists)
                    Directory.CreateDirectory(filePath);

                var url = "";
                if (file.Length > 0)
                {
                    var id = Guid.NewGuid();
                    var fullpath = filePath + $"{id}_{file.FileName.Replace(" ", "")}";

                    using (var image = Image.Load(file.OpenReadStream()))
                    {
                        int width = image.Width;
                        if (image.Width > 800)
                        {
                            width = 800;
                        }
                        image.Mutate(x => x
                             .Resize(width, 0)
                         );

                        image.Save(fullpath);

                        url = url + folder + $"{id}_{file.FileName}";
                    }
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        user.Avatar = url;
                        await _userManager.UpdateAsync(user);
                    }
                }

                return Ok(new
                {
                    Message = "Thành công",
                    Data = $"/{url}"
                }
                );
            }
            catch (Exception exp)
            {

                _logger.LogCritical($"Exception generated when uploading file - {exp.Message} ");
                string message = $"file / upload failed!";
                return Ok(message);
            }
        }

    }
}