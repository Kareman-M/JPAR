namespace JPAR.Infrastructure.IRepository
{
    public interface IRecruiterRepository
    {
        bool Add(string userId, string companyName, string jobTitle);
        Recruiter GetByUserId(string userId);
    }
}