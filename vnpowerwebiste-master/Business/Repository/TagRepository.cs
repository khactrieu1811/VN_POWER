using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;

namespace Business.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
