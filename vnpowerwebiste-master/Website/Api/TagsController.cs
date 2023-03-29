using Business.IRepostitory;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Api
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class TagsController : ControllerBase
    {
        private readonly ILogger<TagsController> _logger;
        private readonly ITagRepository _tagRepository;
        public TagsController(ILogger<TagsController> logger, ITagRepository tagRepository)
        {
            _logger = logger;
            _tagRepository = tagRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _tagRepository.GetAll().ToList();
            var rs = data.Select(x => new { x.Name});
            return Ok(rs);
        }
    }
}
