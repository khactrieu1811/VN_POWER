using AutoMapper;
using Business.IRepostitory;
using Common;
using Entities.DAL;
using Entities.Entities;
using Entities.Helpers;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class ScholarshipRepository : Repository<Scholarship>, IScholarshipRepository
    {
        private readonly IMapper _mapper;
        public ScholarshipRepository(VNPowerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<PaginatedList<ScholarshipResponse>> GetScholarships(string language, string search, int page, int pageSize, string urlServerImage)
        {
            bool isEnglish = language.ToUpper() == "EN";
            var rs = context.Scholarships.Include(x => x.ApplicationUser).Where(x => x.IsApproved &&
                      x.IsEnglish == isEnglish && !x.IsHotPost).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                rs = rs.Where(x => x.Name.Contains(search) || x.MetaDescription.Contains(search)).AsQueryable();
            }

            var data = rs.OrderByDescending(x => x.CreatedDate).AsNoTracking()
             .Select(x => new ScholarshipResponse(x, urlServerImage)).AsQueryable();
            return await PaginatedList<ScholarshipResponse>.CreateAsync(data, page, pageSize);
        }

        public void Insert(ScholarshipModel model)
        {
            var entity = _mapper.Map<Scholarship>(model);
            entity.Id = Guid.NewGuid();
            context.Scholarships.Add(entity);
            if (!string.IsNullOrEmpty(model.Tags))
            {
                var tags = model.Tags.Split(',').ToList().Where(x => !string.IsNullOrEmpty(x));
                entity.MetaDescription = string.Join(",", tags);
                foreach (var tag in tags)
                {
                    var newTag = context.Tags.FirstOrDefault(x => x.Name == tag);
                    if (newTag is null)
                    {
                        newTag = new Tag()
                        {
                            Id = Guid.NewGuid(),
                            Name = tag,
                            Slug = StringUtils.CreateUrlSlug(tag),
                        };
                        context.Tags.Add(newTag);

                    }
                    var tagScholarship = new ScholarshipTag()
                    {
                        TagId = newTag.Id,
                        ScholarshipId = entity.Id
                    };
                    context.ScholarshipTags.Add(tagScholarship);
                }
              
            }
            context.SaveChanges();
        }

        public void Update(Scholarship entity, string tags)
        {
            context.Scholarships.Update(entity);
            if (!string.IsNullOrEmpty(tags))
            {
                var tagList = tags.Split(',').ToList().Where(x => !string.IsNullOrEmpty(x));
                var allTags = context.Tags.Where(x => tagList.Contains(x.Name)).AsNoTracking().ToList();
                var oldTagsforScholarship = context.ScholarshipTags.Where(x => x.ScholarshipId == entity.Id).AsNoTracking().ToList();
                entity.MetaDescription = string.Join(",", tagList);
                foreach (var tag in tagList)
                {
                    var newTag = allTags.FirstOrDefault(x => x.Name == tag);
                    if (newTag is null)
                    {
                        newTag = new Tag()
                        {
                            Id = Guid.NewGuid(),
                            Name = tag,
                            Slug = StringUtils.CreateUrlSlug(tag),
                        };
                        context.Tags.Add(newTag);
                        var tagScholarship = new ScholarshipTag()
                        {
                            TagId = newTag.Id,
                            ScholarshipId = entity.Id
                        };
                        context.ScholarshipTags.Add(tagScholarship);

                    }
                    else
                    {
                        oldTagsforScholarship = oldTagsforScholarship.Where(x => x.TagId != newTag.Id).ToList();
                    }

                }
                context.ScholarshipTags.RemoveRange(oldTagsforScholarship);
               
            }
            context.SaveChanges();
        }
    }

    public class ScholarshipTypeRepository : Repository<ScholarshipType>, IScholarshipTypeRepository
    {
        public ScholarshipTypeRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
