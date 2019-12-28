namespace AuthenticationServer.DataLayer
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByDomainSID(string domainSid);
    }
}