using Business.IRepostitory;
using Entities.DAL;
using Entities.Entities;

namespace Business.Repository
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(VNPowerContext context) : base(context)
        {

        }
    }
}
