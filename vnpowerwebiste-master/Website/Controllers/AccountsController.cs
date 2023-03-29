using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Business.IRepostitory;
using Common;
using Entities.Entities;
using Entities.Helpers;
using Model;
using Model.Permissions;
using Website.Models;
using Website.Services;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Controllers
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountsController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPartnerRepository _doctorRepository;
        private IWebHostEnvironment _hostingEnvironment;
        private int _pageSize = 10;
        private string _prefixPassword = "Mh@";
        private string _prefixPasswordAdmin = "Tnr@";
        // private readonly IDataAccessService _dataAccessService;
        public AccountsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService, //IDataAccessService dataAccessService,
            IUserRepository userRepository,// RoleManager<ApplicationUserRole> roleManager,
            IMapper mapper, ILogger<AccountsController> logger, IPartnerRepository doctorRepository, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
           // _roleManager = roleManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _doctorRepository = doctorRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("accounts/getall")]
        public async Task<IActionResult> Index(int? page)
        {
            var filter = HttpContext.Request.Query["search"];
            var lockout = HttpContext.Request.Query["lockout"];
            if (page == null)
            {
                page = 1;
            }


            var rs = _userRepository.GetAllData().Where(x => x.LockoutEnabled != false);
            if (!string.IsNullOrEmpty(filter.ToString()))
            {
                ViewData["CurrentFilter"] = filter.ToString();
                rs = rs.Where(x => x.UserName.Contains(filter.ToString()) || x.FullName.Contains(filter.ToString()) || x.Email.Contains(filter.ToString()));
            }
            if(!string.IsNullOrEmpty(lockout.ToString()))
            {
                if(lockout.ToString().Equals("active"))
                {
                    rs = rs.Where(x => x.LockoutEnd == null);
                }
                else
                {
                    rs = rs.Where(x => x.LockoutEnd != null);
                }
            }
            ViewData["Lockout"] = lockout.ToString();
            return View(await PaginatedList<ApplicationUser>.CreateAsync(rs.AsNoTracking(), page ?? 1, _pageSize));
        }
        [HttpGet("accounts/edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            // var rs = _userRepository.GetDatabyFiler(x => x.FullName.Contains(filter) || x.UserName.Contains(filter));

            return View(user);
        }

        [HttpPost("accounts/addUser")]
        public async Task<JsonResult> AddUser([FromBody] UserRegisterModel model)
        {
            var rs = new ResponseModel<int>() { Message = $"Tài khoản {model.HISCode} đã tồn tại", Success = false };
            var user = await _userManager.FindByNameAsync(model.HISCode);
            if (user != null) return Json(rs);
            try
            {                
                var insert = new ApplicationUser()
                {
                    UserName = model.HISCode,
                    FullAddress = model.Address,
                    BirthDay = DateTime.ParseExact(model.Birthday, "dd-MM-yyyy", null),
                    Email = model.Email,
                    FullName = model.FullName,
                    Sex = model.Sex,
                    PhoneNumber = model.PhoneNumber
                };
                var password = $"{_prefixPassword}123456";
                var result = await _userManager.CreateAsync(insert, password);
                if (result.Succeeded)
                {
                    rs.Success = true;
                    rs.Message = "Thêm tài khoản thành công.";
                }

            }
            catch (Exception ex)
            {
                rs.Message = "Có lỗi xãy ra, vui lòng kiểm tra lại thông tin";
                _logger.LogError(ex, ex.Message);
            }
            return Json(rs);
        }

        [HttpGet("accounts/EditUser/{id}")]
        public IActionResult EditUser(string id)
        {
            var user = _userRepository.GetByStringId(id);
            var model = new UserRegisterModel
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Address = user.FullAddress,
                Birthday = user.BirthDay.ToString("dd-MM-yyyy"),
                PhoneNumber = user.PhoneNumber,
                Sex = user.Sex,
            };
            return View(model);
        }
        [HttpPost("accounts/EditUser")]
        [Authorize]
        public IActionResult EditUser(UserRegisterModel model)
        {
            try
            {
                var user = _userRepository.GetByStringId(model.Id);
                if (user != null)
                {
                    user.FullAddress = model.Address;
                    user.BirthDay = DateTime.ParseExact(model.Birthday, "dd-MM-yyyy", null);
                    user.Email = model.Email;
                    user.FullName = model.FullName;
                    user.Sex = model.Sex;
                    user.PhoneNumber = model.PhoneNumber;
                    _userRepository.Update(user);
                    return RedirectToAction("Index");
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }
        [HttpGet("/accounts/RemoveUser/{id}")]
        public IActionResult RemoveUser(string id)
        {
            try
            {
                var user = _userRepository.GetByStringId(id);

                if (user != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = string.Format("User chưa được khóa"),
                        Success = false
                    };
                    if (user.LockoutEnd != null)
                    {
                        user.LockoutEnabled = false;
                        _userRepository.Update(user);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa User");
                        rs.Success = true;
                    }
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }


        [HttpGet("accounts/detail/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            // var rs = _userRepository.GetDatabyFiler(x => x.FullName.Contains(filter) || x.UserName.Contains(filter));

            return PartialView(user);
        }
        [HttpGet("accounts/delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rs = new ResultObject<int>()
            {
                Message = $"Có lỗi xãy ra.",
                Status = false
            };
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    rs.Message = $"Xóa tài khoản {user.UserName} thành công.";
                    rs.Status = true;
                }
            }
            else
            {
                rs.Message = "Tài khoản không tồn tại.";
            }

            return Json(rs);

        }

        [HttpGet("admin/Signin")]
        [AllowAnonymous]
        public IActionResult Logon()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost("admin/Signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Logon(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Email == model.UserName || x.UserName == model.UserName);
                if (user != null)
                {
                    if (user.LockoutEnd != null)
                    {
                        ModelState.AddModelError(string.Empty, $"Tài khoản {model.UserName} đã bị khóa.");
                        return View();
                    }
                    var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, model.RememberMe);
                    if (check.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        // To do
                        var token = _tokenService.GenerateAccessToken(user, 0, _userManager);
                        // HttpContext.Session.SetString("JWToken", token);
                        Response.Cookies.Append("x-headertoken",
                                token,
                                new CookieOptions()
                                {
                                    Path = "/"
                                }
                            );


                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Mật khẩu không đúng.");
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Tài khoản {model.UserName} không tồn tại.");
                }


            }

            return View();
        }

        [HttpGet("admin/logout")]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Logon", "Accounts");
        }


        [HttpGet("accounts/getAdminStaff")]
        public async Task<IActionResult> AdministratorStaff(int? page)
        {
            var search = HttpContext.Request.Query["search"];
            var roleId = HttpContext.Request.Query["RoleId"];
            var status = HttpContext.Request.Query["Status"];
            if (page == null)
            {
                page = 1;
            }
            
            var rs = _userRepository.GetAdminStaffs(roleId, status,search);
            ViewData["CurrentFilter"] = search.ToString();
            ViewData["RoleId"] = roleId.ToString();
            ViewData["Status"] = status.ToString();
          
            return View(await PaginatedList<AdminStaffModel>.CreateAsync(rs, page ?? 1, _pageSize));
        }

        [HttpGet("/accounts/LockOrUnlock/{id}/{value}")]
        public IActionResult LockOrUnLockStaff(string id, int value)
        {
            try
            {
                var user = _userRepository.GetByStringId(id);

                if (user.LockoutEnabled == true)
                {
                    if (user != null)
                    {
                        var rs = new ResponseModel<int>();
                        if (value == 1)
                        {
                            user.LockoutEnd = DateTime.Now;
                            rs.Message = string.Format(MessageConstants.Success, "Khóa User");
                            rs.Success = true;

                        }
                        else
                        {
                            user.LockoutEnd = null;
                            rs.Message = string.Format(MessageConstants.Success, "Mở khóa User");
                            rs.Success = true;
                        }
                        _userRepository.Update(user);

                        return Json(rs);
                    }
                    var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                    return Json(notExist);
                }
                var deActive = new ResponseModel<int>() { Message = "User đã bị xóa", Success = false };
                return Json(deActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        [HttpGet("/accounts/RemoveStaff/{id}")]
        public IActionResult RemoveStaff(string id)
        {
            try
            {
                var user = _userRepository.GetByStringId(id);

                if (user != null)
                {
                    var rs = new ResponseModel<int>()
                    {
                        Message = string.Format("User chưa được khóa"),
                        Success = false
                    };
                    if(user.LockoutEnd != null)
                    {
                        user.LockoutEnabled = false;
                        _userRepository.Update(user);
                        rs.Message = string.Format(MessageConstants.Success, "Xóa User");
                        rs.Success = true;
                    }    
                    return Json(rs);
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        [HttpPost("/accounts/PermissionStaff/{userId}/{roleName}")]
        public async Task<IActionResult> PermissionStaff(string userId,string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if(user == null)
                {
                    var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                    return Json(error);
                }
                var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                if (rolesList.Any())
                {
                    foreach(var r in rolesList)
                    {
                       _ = await _userManager.RemoveFromRoleAsync(user, r);
                    }
                }

                var rs = new ResponseModel<int>()
                {
                    Message = string.Format(MessageConstants.Error),
                    Success = false
                };
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    rs.Message = string.Format(MessageConstants.Success, "Phân quyền");
                    rs.Success = true;
                }
              
              
                return Json(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        [HttpPost("/accounts/ResetPassword/{userId}")]
        public async Task<IActionResult> ResetPassword(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                    return Json(error);
                }
                var rs = new ResponseModel<int>()
                {
                    Message = string.Format(MessageConstants.Error),
                    Success = false
                };
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, $"{_prefixPasswordAdmin}123456");
                if (result.Succeeded)
                {
                    rs.Message = string.Format(MessageConstants.Success, "Reset mật khẩu");
                    rs.Success = true;
                }


                return Json(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }

        [HttpGet("accounts/AddAdministrator")]
        public IActionResult AddAdministrator()
        {
            return View();
        }

        [HttpPost("accounts/AddAdministrator")]
        public async Task<IActionResult> AddAdministrator(AdministratorModel model)
        {
            if (ModelState.IsValid)
            {
                var rs = new ResponseModel<int>() { Message = $"Tài khoản {model.UserName} đã tồn tại", Success = false };
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    ModelState.AddModelError(string.Empty, $"Tài khoản {model.UserName} đã tồn tại");
                    return View();
                }
                
                try
                {
                    var insert = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FullName = model.FullName,
                    };
                    var result = await _userManager.CreateAsync(insert, model.Password);
                    await _userManager.AddToRoleAsync(insert, model.RoleName);
                    if (model.DoctorId != 0)
                    {
                       /* var doctor = _doctorRepository.GetById(model.DoctorId);
                        if (doctor != null)
                        {
                            doctor.UserId = insert.Id;
                            _doctorRepository.Update(doctor);
                        }*/
                    }
                    if (result.Succeeded)
                    {
                        rs.Success = true;
                        rs.Message = "Thêm tài khoản quản trị thành công.";
                    }
                    return RedirectToAction("AdministratorStaff");
                }
                catch (Exception ex)
                {
                    rs.Message = "Có lỗi xãy ra, vui lòng kiểm tra lại thông tin";
                    _logger.LogError(ex, ex.Message);
                }              
            }
            return View();
        }
        [HttpGet("accounts/EditAdminStaff/{userId}")]
        public IActionResult EditAdminStaff(string userId)
        {

            var user = _userRepository.GetByStringId(userId);
         //   var doctor = _doctorRepository.GetByFiler(x=>x.UserId == userId);
            if (user != null && user.LockoutEnabled != false)
            {
                var model = new AdministratorModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    UserName = user.UserName,
                   // DoctorId = doctor.Count() == 0 ? 0 : doctor.FirstOrDefault().Id
                };
                return View(model);
            }
            return RedirectToAction("AdministratorStaff");
        }
        [HttpPost("accounts/EditAdminStaff")]
        public IActionResult EditAdminStaff(AdministratorModel model)
        {
            try
            {
                var user = _userRepository.GetByStringId(model.Id);

                if (user != null)
                {
                    user.Email = model.Email;
                    user.FullName = model.FullName;
                    _userRepository.Update(user);
                    if (model.DoctorId != 0)
                    {
                        var doctor = _doctorRepository.GetById(model.DoctorId);
                        if (doctor != null)
                        {
                           // doctor.UserId = user.Id;
                            _doctorRepository.Update(doctor);
                        }
                    }
                    return RedirectToAction("AdministratorStaff");
                }
                var notExist = new ResponseModel<int>() { Message = string.Format(MessageConstants.NotExists, "User"), Success = false };
                return Json(notExist);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                var error = new ResponseModel<int>() { Message = string.Format(MessageConstants.Error, ""), Success = false };
                return Json(error);
            }
        }


        public async Task<IActionResult> Export(string lockout)
        {

            var query = _userRepository.GetAllData().Where(x => x.LockoutEnabled != false);           
            if (!string.IsNullOrEmpty(lockout))
            {
                if (lockout.ToString().Equals("active"))
                {
                    query = query.Where(x => x.LockoutEnd == null);
                }
                else
                {
                    query = query.Where(x => x.LockoutEnd != null);
                }
            }

            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $@"DanhSach_NguoiDung.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Question");
                IRow row = excelSheet.CreateRow(0);
                row.CreateCell(0).SetCellValue("Mã y tế");
                row.CreateCell(1).SetCellValue("Tên người dùng");
                row.CreateCell(2).SetCellValue("Tên tài khoản");
                row.CreateCell(3).SetCellValue("Email");
                row.CreateCell(4).SetCellValue("Số điện thoại");
                row.CreateCell(5).SetCellValue("Địa chỉ");
                row.CreateCell(6).SetCellValue("Giới tính");
                row.CreateCell(7).SetCellValue("Ngày sinh");
                row.CreateCell(8).SetCellValue("Trạng thái");               
                var data = await query.ToListAsync();
                int i = 1;
                foreach (var item in data)
                {
                    row = excelSheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue("");
                    row.CreateCell(1).SetCellValue(item.FullName);
                    row.CreateCell(2).SetCellValue(item.UserName);
                    row.CreateCell(3).SetCellValue(item.Email);
                    row.CreateCell(4).SetCellValue(item.PhoneNumber);
                    row.CreateCell(5).SetCellValue(item.FullAddress);
                    row.CreateCell(6).SetCellValue(item.Sex);
                    row.CreateCell(7).SetCellValue(item.BirthDay.ToString("dd-MM-yyyy"));                   
                    if (item.LockoutEnd == null)
                    {
                        row.CreateCell(8).SetCellValue("Đang hoạt động");
                    }
                    else if (item.LockoutEnd != null)
                    {
                        row.CreateCell(8).SetCellValue("Đang tạm khóa");
                    }                  
                    i++;
                }
                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
    }
}