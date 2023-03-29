using Business.IRepository;
using Entities.Entities;
using Entities.Helpers;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepostitory
{
    public interface IScholarshipRepository : IRepository<Scholarship>
    {
        public void Insert(ScholarshipModel model);
        public void Update(Scholarship entity, string tags);

        Task<PaginatedList<ScholarshipResponse>> GetScholarships(string language, string search, int page, int pageSize, string urlServerImage);

    }

    public interface IScholarshipTypeRepository : IRepository<ScholarshipType>
    {

    }
}
