using Business.IRepostitory;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Api
{
    [Route("api")]
    [ApiController]
    public class ScholarshipsController : ControllerBaseApi
    {
        private readonly IScholarshipRepository _scholarshipRepository;
        private readonly ILogger<HomesController> _logger;
        public ScholarshipsController(ILogger<HomesController> logger, IHttpContextAccessor httpContextAccessor,
            IScholarshipRepository scholarshipRepository) : base(httpContextAccessor)
        {
            _logger = logger;
            _scholarshipRepository = scholarshipRepository;

        }

        [HttpGet("Scholarships/{language}")]
        public async Task<IActionResult> GetAll(string language, string search, int? page, int? pageSize)
        {
            pageSize ??= 10;
            page ??= 1;
            var data = await _scholarshipRepository.GetScholarships(language, search, page.Value, pageSize.Value, GetUrlServerImage());
            var rs = new PagedResult<ScholarshipResponse>()
            {
                CurrentPage = data.PageIndex,
                TotalItems = data.TotalRows,
                PageSize = pageSize.Value,
                Results = data.ToList(),
                PageCount = data.TotalPages
            };
            return Ok(rs);
        }

        [HttpGet("Scholarships/hotlist/{language}")]
        public async Task<IActionResult> GetHotScholarship(string language)
        {
            bool isEnglish = language.ToUpper() == "EN";
            var data = await _scholarshipRepository.GetAllData().Include(x=>x.ApplicationUser)
                .Where(x => x.IsApproved && x.IsHotPost && x.IsEnglish == isEnglish)
                .OrderByDescending(x => x.CreatedDate).Take(6).ToListAsync();
              var rs =   data.Select(x=> new ScholarshipResponse(x, GetUrlServerImage())).ToList();
           
            return Ok(rs);
        }


        [HttpGet("Scholarships/Detail/{slug}")]
          public async Task<IActionResult> Detail(string slug)
          {
              var data = await _scholarshipRepository.GetAllData().Include(x=>x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Slug == slug);
              return Ok(new ScholarshipDetailResponse(data, GetUrlServerImage()));
          }
    }
}
