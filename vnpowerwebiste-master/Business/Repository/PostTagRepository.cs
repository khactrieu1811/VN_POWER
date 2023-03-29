using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;

namespace Business.Repository
{
    public class PostTagRepository : Repository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
