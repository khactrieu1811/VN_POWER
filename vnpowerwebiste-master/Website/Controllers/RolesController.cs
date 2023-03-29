using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.IRepostitory;
using Entities.Entities;
using Model.Permissions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;
        private readonly IMapper _mapper;
        private readonly IRolesRepository _rolesRepository; 
        public RolesController (RoleManager<IdentityRole> roleManager, ILogger<RolesController> logger, IRolesRepository rolesRepository, IMapper mapper)
        {
            this._roleManager = roleManager;
            this._logger = logger;
            this._rolesRepository = rolesRepository;
            this._mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = this._rolesRepository.GetAll().ToList();
                var rs = data.Select(x => new { x.Id, x.Name, x.Description });
                return Ok(rs);
            }
            catch (Exception ex)
            {

            }

            return Ok();


        }
        [HttpGet("GetFitterByName")]
        public async Task<IActionResult> GetFitterByName(string name)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = this._rolesRepository.GetAll().Where(x => x.Name.ToUpper().Contains(name.ToUpper()) || x.Description.ToUpper().Contains(name.ToUpper())).ToList();
                    var rs = data.Select(x => new { x.Id, x.Name, x.Description });
                    return Ok(rs);
                }
                catch(Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    return BadRequest("Có lỗi xảy ra.");
                }
            }
            return BadRequest("Truy cập không hợp lệ");
        }
        // POST: api/Roles
        [HttpPost("InsertOrUpdate")]
        public async Task<IActionResult> InsertOrUpdate([FromBody]RoleModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(model.Id))
                    {
                        var role = new ApplicationRole { Description = model.Description, Name = model.Name };
                        var result = await _roleManager.CreateAsync(role);
                        if (result.Succeeded)
                        {
                            var data = this._rolesRepository.GetAll();
                            var list = data.Select(x => new { x.Id, x.Description, x.Name });
                            return Ok(new { data = list });
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        var role = _rolesRepository.GetByFiler(x => x.Id == model.Id).FirstOrDefault();
                        role.Name = model.Name;
                        role.Description = model.Description;
                       var rs = await _roleManager.UpdateAsync(role);
                        if (rs.Succeeded)
                        {
                            var data = this._rolesRepository.GetAll();
                            var list = data.Select(x => new { x.Id, x.Description, x.Name });
                            return Ok(list);
                        }
                        else
                        {
                            return BadRequest(new { message = "Lỗi update dữ liệu." });
                        }
                    }
                }
                catch(Exception ex)
                {
                    this._logger.LogError(ex, ex.Message);
                    return BadRequest(new { message = "Có lỗi xảy ra." });
                }       
            }
            return BadRequest(new { message = "MessageConstants.BadRequest" });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var role = _rolesRepository.GetByFiler(x => x.Id == id).FirstOrDefault();
                    var rs = await _roleManager.DeleteAsync(role);
                    if (rs.Succeeded)
                    {
                        var data = this._rolesRepository.GetAll();
                        var list = data.Select(x => new { x.Id, x.Description, x.Name });
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
            return BadRequest(new { message = "Truy cập không hợp lệ" });
        }

    }
}
