using System.Linq;

namespace AuthenticationServer.DataLayer
{
    public class UsersRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUserByDomainSID(string domainSid)
        {
            return _dbContext.Users.FirstOrDefault(x => x.DomainSID == domainSid);
        }
    }
}