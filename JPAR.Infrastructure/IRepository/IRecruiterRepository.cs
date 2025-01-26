namespace JPAR.Infrastructure.IRepository
{
    public interface IRecruiterRepository
    {
        bool Add(string userId);
        Recruiter GetByUserId(string userId);
    }
}