using Business.IRepostitory;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;

        }
        // GET: api/<RegionsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_regionRepository.GetAll());
        }

        // GET api/<RegionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var first = _regionRepository.GetById(id);
            return Ok(first);
        }

        // POST api/<RegionsController>
        [HttpPost]
        public IActionResult Post([FromBody] Region entity)
        {
            if(entity != null)
            {
                _regionRepository.Add(entity);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<RegionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Region entity)
        {
            var tobeUpdate = _regionRepository.GetById(id);
            if (tobeUpdate != null)
            {
                tobeUpdate.Name = entity.Name;
                tobeUpdate.NameEN = entity.NameEN;
                tobeUpdate.DescriptionEN = entity.DescriptionEN;
                tobeUpdate.Description = entity.Description;
                _regionRepository.Update(tobeUpdate);
            }
        }

        // DELETE api/<RegionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = _regionRepository.GetById(id);
            if(delete != null)
            {
                _regionRepository.Delete(delete);
            }
        }
    }
}
