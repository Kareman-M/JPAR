namespace JPAR.Infrastructure.IRepository
{
    public interface IApplicantRepository
    {
        Applicant GetById(int id);
        Applicant GetByUserId(string userId);
        bool Add(string userId);
        Applicant Update(Applicant applicant);
        bool Delete(int id);
    }
}
