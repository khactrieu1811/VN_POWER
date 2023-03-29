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
    public class ScholarshipTypesController : ControllerBase
    {
        private readonly IScholarshipTypeRepository _scholarshipTypeRepository;
        public ScholarshipTypesController(IScholarshipTypeRepository scholarshipTypeRepository)
        {
            _scholarshipTypeRepository = scholarshipTypeRepository;

        }
        // GET: api/<RegionsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_scholarshipTypeRepository.GetAll());
        }

        // GET api/<RegionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var first = _scholarshipTypeRepository.GetById(id);
            return Ok(first);
        }

        // POST api/<RegionsController>
        [HttpPost]
        public IActionResult Post([FromBody] ScholarshipType entity)
        {
            if(entity != null)
            {
                _scholarshipTypeRepository.Add(entity);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<RegionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ScholarshipType entity)
        {
            var tobeUpdate = _scholarshipTypeRepository.GetById(id);
            if (tobeUpdate != null)
            {
                tobeUpdate.Name = entity.Name;
                tobeUpdate.NameEN = entity.NameEN;
                tobeUpdate.DescriptionEN = entity.DescriptionEN;
                tobeUpdate.Description = entity.Description;
                _scholarshipTypeRepository.Update(tobeUpdate);
            }
        }

        // DELETE api/<RegionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = _scholarshipTypeRepository.GetById(id);
            if(delete != null)
            {
                _scholarshipTypeRepository.Delete(delete);
            }
        }
    }
}
