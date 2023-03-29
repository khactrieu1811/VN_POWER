using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Model.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMenuPermissionController : ControllerBase
    {
        private readonly ILogger<RoleMenuPermissionController> _logger;
        private readonly IMapper _mapper;
        private readonly IRoleMenuPermissionRepository _roleMenuPermissionRepository;
        private readonly INavigationMenuRepository _navigationMenuRepository;

        public RoleMenuPermissionController(INavigationMenuRepository navigationMenuRepository, IRoleMenuPermissionRepository roleMenuPermissionRepository, ILogger<RoleMenuPermissionController> logger, IMapper mapper)
        {
            this._navigationMenuRepository = navigationMenuRepository;
            this._roleMenuPermissionRepository = roleMenuPermissionRepository;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: api/RoleMenuPermission
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = _navigationMenuRepository.GetAll().ToList();
                var rs = data.Select(x => new { x.Id, x.Name, x.ControllerName, x.ActionName, x.Visible, x.IsMenu });
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Ok();


        }
        // GET: api/RoleMenuPermission/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var data = this._roleMenuPermissionRepository.GetIncludes(x => x.NavigationMenu).Where(x => x.RoleId.ToUpper().Contains(id.ToUpper()) && x.NavigationMenu.Visible == false).ToList();
                    var rs = data.Select(x => new { x.RoleId, x.NavigationMenuId, x.NavigationMenu.Name, x.NavigationMenu.ControllerName, x.NavigationMenu.ActionName });
                    return Ok(rs);
                }
                else
                    return BadRequest("Có lỗi xảy ra");
               
            }
            return BadRequest("Truy cập không liệu");
               
        }

        // POST: api/RoleMenuPermission
        [HttpPost("InsertOrUpdate")]
        public async Task<IActionResult> InsertOrUpdate([FromBody]RoleMenuPermissionModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Guid NavigationMenuId = Guid.Parse(model.NavigationMenuId);
//                    var dmChitiet = this._mapper.Map<RoleMenuPermission>(model);
                    this._roleMenuPermissionRepository.Add(new RoleMenuPermission() { RoleId = model.RoleId, NavigationMenuId = NavigationMenuId });
                    var data = this._roleMenuPermissionRepository.GetIncludes(x => x.NavigationMenu).Where(x => x.RoleId.ToUpper().Contains(model.RoleId.ToUpper()) && x.NavigationMenu.Visible == false).ToList();
                    var list = data.Select(x => new { x.RoleId, x.NavigationMenuId, x.NavigationMenu.Name, x.NavigationMenu.ControllerName, x.NavigationMenu.ActionName });
                    return Ok(new { message = "Thành công.", data = list });
                }
                catch(Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    var data = this._roleMenuPermissionRepository.GetIncludes(x => x.NavigationMenu).Where(x => x.RoleId.ToUpper().Contains(model.RoleId.ToUpper()) && x.NavigationMenu.Visible == false).ToList();
                    var list = data.Select(x => new { x.RoleId, x.NavigationMenuId, x.NavigationMenu.Name, x.NavigationMenu.ControllerName, x.NavigationMenu.ActionName });
                    return BadRequest(new { message = "Quyền này đã được khai báo.", data = list });
                }
            }
            return BadRequest("Truy cập không hợp lệ");
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody]RoleMenuPermissionModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var rs = this._roleMenuPermissionRepository.GetAll().Where(x => x.RoleId.ToUpper().Contains(model.RoleId.ToUpper()) && x.NavigationMenuId.ToString().ToUpper().Contains(model.NavigationMenuId.ToUpper())).ToList();
                    this._roleMenuPermissionRepository.DeleteEntities(rs);
                    var data = this._roleMenuPermissionRepository.GetIncludes(x => x.NavigationMenu).Where(x => x.RoleId.ToUpper().Contains(model.RoleId.ToUpper()) && x.NavigationMenu.Visible == false).ToList();
                    var list = data.Select(x => new { x.RoleId, x.NavigationMenuId, x.NavigationMenu.Name, x.NavigationMenu.ControllerName, x.NavigationMenu.ActionName });
                    return Ok(new { message = "Xóa thành công.", data = list });
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    return BadRequest(new { message = "Có lỗi xảy ra." });
                }
            }
            return BadRequest(new { message = "Truy cập không hợp lệ" });
        }
    }
}
