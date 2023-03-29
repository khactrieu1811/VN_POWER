using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Model.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRolesRepository _rolesRepository;
        public UserRoleController(IRolesRepository rolesRepository, RoleManager<IdentityRole> roleManager, IUserRoleRepository userRoleRepository, UserManager<IdentityUser> userManager, ILogger<UserRoleController> logger, IMapper mapper)
        {
            this._userManager = userManager;
            this._userRoleRepository = userRoleRepository;
            this._roleManager = roleManager;
            this._rolesRepository = rolesRepository;
            this._logger = logger;
            this._mapper = mapper;
        }
        // GET: api/UserRole
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string id)
        {
            try
            {
                var rs = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(id.ToUpper())).ToList();
                var role = this._rolesRepository.GetAll().Where(x => rs.Select(f => f.RoleId).Contains(x.Id)).ToList();
                var list = role.Select(x => new { x.Name, x.Description, x.Id});
                return Ok(list);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);
                return BadRequest("Có lỗi xảy ra.");
            }

            return Ok();


        }

        // GET: api/UserRole/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRole
        [HttpPost("InsertOrUpdate")]
        public async Task<IActionResult> InsertOrUpdate([FromBody]UserRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var rs = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper()) && x.RoleId.ToUpper().Contains(model.RoleId.ToUpper())).ToList();
                if (rs.Count == 0)
                {
                    var chitietUserRole = new IdentityUserRole<string> { UserId = model.UserId, RoleId = model.RoleId };
                    this._userRoleRepository.Add(chitietUserRole);

                    var data = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper())).ToList();
                    var role = this._rolesRepository.GetAll().Where(x => data.Select(f => f.RoleId).Contains(x.Id)).ToList();
                    var list = role.Select(x => new { x.Name, x.Description, x.Id });
                    return Ok(new { message = "Thành công", data = list });
                }
                else
                {
                    var data = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper())).ToList();
                    var role = this._rolesRepository.GetAll().Where(x => data.Select(f => f.RoleId).Contains(x.Id)).ToList();
                    var list = role.Select(x => new { x.Name, x.Description, x.Id });
                    return BadRequest(new { message = "Quyền này đã được khai báo", data = list });
                }
              
            }
            return BadRequest("Truy cập không hợp lệ.");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody]UserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rs = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper()) && x.RoleId.ToUpper().Contains(model.RoleId.ToUpper())).ToList();
                    this._userRoleRepository.DeleteEntities(rs);

                    var data = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper())).ToList();
                    var role = this._rolesRepository.GetAll().Where(x => data.Select(f => f.RoleId).Contains(x.Id)).ToList();
                    var list = role.Select(x => new { x.Name, x.Description, x.Id });
                    return Ok(new { message = "Xóa thành công", data = list });
                }
                catch(Exception ex)
                {
                    var rs = this._userRoleRepository.GetAll().Where(x => x.UserId.ToUpper().Contains(model.UserId.ToUpper())).ToList();
                    var role = this._rolesRepository.GetAll().Where(x => rs.Select(f => f.RoleId).Contains(x.Id)).ToList();
                    var list = role.Select(x => new { x.Name, x.Description, x.Id });
                    return BadRequest(new { message = "Có lỗi xảy ra.", data = list });
                }
               
            }
            return BadRequest("Truy cập không hợp lệ.");
        }
    }
}
