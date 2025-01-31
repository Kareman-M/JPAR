using JPAR.Infrastructure.Enums;
using JPAR.Infrastructure.IRepository;
using JPAR.Infrastructure.Models;
using JPAR.Service.DTOs;
using JPAR.Service.IServices;

namespace JPAR.Service.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobPostRepository;
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly IApplicantRepository _applicantRepository;

        public JobService(IJobRepository jobPostRepository, IRecruiterRepository recruiterRepository, IApplicantRepository applicantRepository)
        {
            this._jobPostRepository = jobPostRepository;
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
        }

        public bool Add(AddJobDTO addJobPostDTO, string userId)
        {
            var recruiterId = _recruiterRepository.GetByUserId(userId).Id;
            var job = new Job
            {
                Title = addJobPostDTO.Title,
                JobDescription = addJobPostDTO.JobDescription,
                CareerLevel = addJobPostDTO.CareerLevel,
                JobCategories = addJobPostDTO.Categories.Select(x=> new JobCategory { Category= x}).ToList(),
                Country = addJobPostDTO.Country,
                HideSalary = addJobPostDTO.HideSalary,
                JobTypes = addJobPostDTO.JobTypes.Select(x => new JobType { Type = x }).ToList(),
                NumberOfVecancy = addJobPostDTO.NumberOfVecancy,
                WorkPlace = addJobPostDTO.WorkPlace,
                AdditinalSalaryDetails = addJobPostDTO.AdditinalSalaryDetails,
                MinSalaryRange = addJobPostDTO.MinSalaryRange,
                MaxSalaryRange = addJobPostDTO.MaxSalaryRange,
                MinYearsOfExperince = addJobPostDTO.MinYearsOfExperince,
                MaxYearsOfExperince = addJobPostDTO.MaxYearsOfExperince,
                Status = JobStatus.Open,
                RecruiterId = recruiterId,
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
            };
            return _jobPostRepository.Add(job);
        }

        public bool ChangeStatus(int jobPostId, JobStatus jobPostStatus)
            => _jobPostRepository.ChangeStatus(jobPostId, jobPostStatus);

        public List<JobDTO> GetByUserId(string userId)
        {
            var data = _jobPostRepository.GetByUserId(userId);
            return MapJobToDTO(data);
        }

        public List<JobDTO> GetApplicantMatchedJobs(ApplicantJobFilterDTO filter, string applicantUserId)
        {
            var jobs = _jobPostRepository.GetAll();

            var user = _applicantRepository.GetByUserId(applicantUserId);

            jobs = GetFilteredJobs(filter, jobs);

            jobs = GetMatchedJobs(jobs, user);

            return jobs.OrderBy(x => x.CreatedAt).Select(x => new JobDTO
            {

            }).ToList();
        }

        private IQueryable<Job> GetMatchedJobs(IQueryable<Job> jobs, Applicant user)
        {

            if (!string.IsNullOrEmpty(user.Country) || !string.IsNullOrEmpty(user.City) || !string.IsNullOrEmpty(user.Area))
                jobs = jobs.Where(x =>
                x.Country.ToLower().Contains(user.Country.ToLower()) ||
                x.Country.ToLower().Contains(user.City.ToLower()) ||
                x.Country.ToLower().Contains(user.Area.ToLower()));

            if (user.Level != null)
                jobs = jobs.Where(x => x.CareerLevel == user.Level);

            if (user.JobType != null)
                jobs = jobs.Where(x => x.JobTypes.Any(x => user.JobType.Any(c => c.Name == x.Type)));

            if (user.IndustryCategories.Any())
                jobs = jobs.Where(x => x.JobCategories.Select(x=> x.Category).Any(j=> user.IndustryCategories.Select(x=> x.Category).Contains(j)));

            if (user.WorkPlace != null)
                jobs = jobs.Where(x => user.WorkPlace.Any(w=> w.Name == x.WorkPlace));

            if (user.DesiredNetSalaryPerMonth != null || user.DesiredNetSalaryPerMonth > 0)
                jobs = jobs.Where(x => x.MinSalaryRange >= user.DesiredNetSalaryPerMonth);

            return jobs;
        }

        private IQueryable<Job> GetFilteredJobs(ApplicantJobFilterDTO filter, IQueryable<Job> jobs)
        {
            if (!string.IsNullOrEmpty(filter.Location))
                jobs = jobs.Where(x => x.Country.ToLower().Contains(filter.Location.ToLower()));
            if (!string.IsNullOrEmpty(filter.CareerLevel))
                jobs = jobs.Where(x => x.CareerLevel.ToString().ToLower().Contains(filter.CareerLevel.ToLower()));
            if (!string.IsNullOrEmpty(filter.JobCategory))
                jobs = jobs.Where(x => x.JobCategories.Select(x=> x.Category).Any(c => c.ToLower().Contains(filter.JobCategory.ToLower())));
            return jobs;
        }
     
        private List<JobDTO> MapJobToDTO(List<Job> data)
        {
            return data.Select(x => new JobDTO
            {
                Id = x.Id,
                Title = x.Title,
                JobTypes = x.JobTypes.Select(j => j.ToString()).ToList(),
                Status = x.Status.ToString(),
                MaxSalaryRange = x.MaxSalaryRange,
                MaxYearsOfExperince = x.MaxYearsOfExperince,
                MinSalaryRange = x.MinSalaryRange,
                MinYearsOfExperince = x.MinYearsOfExperince,
                NumberOfVecancy = x.NumberOfVecancy,
                RecruiterId = x.RecruiterId,
                CompanyName = x.Recruiter.CompanyName,
                WorkPlace = x.WorkPlace.ToString(),
                AdditinalSalaryDetails = x.AdditinalSalaryDetails,
                JobDescription = x.JobDescription,
                CareerLevel = x.CareerLevel.ToString(),
                Categories = x.JobCategories.Select(x=> x.Category).ToList(),
                Country = x.Country,
                HideSalary = x.HideSalary,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
            }).ToList();
        }
    }
}
