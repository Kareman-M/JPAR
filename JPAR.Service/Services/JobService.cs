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
        private readonly IApplicantJobRepository _applicantJobRepository;

        public JobService(IJobRepository jobPostRepository, IRecruiterRepository recruiterRepository, IApplicantRepository applicantRepository, IApplicantJobRepository applicantJobRepository)
        {
            this._jobPostRepository = jobPostRepository;
            _recruiterRepository = recruiterRepository;
            _applicantRepository = applicantRepository;
            _applicantJobRepository = applicantJobRepository;
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

           // var data = GetMatchedJobsForApplicant(jobs, user);

            return MapJobToDTO(jobs.OrderBy(x => x.CreatedAt).ToList());
        }

        public (JobDTO Job, bool CanApply) GetById(int jobPostId, string userId)
        {
            var job = _jobPostRepository.GetById(jobPostId);
            if (job == null) return (null, false);
            var canApplicantApplay = _applicantJobRepository.CanApplicantApplay(userId, jobPostId);
            return (new JobDTO
            {
                AdditinalSalaryDetails = job.AdditinalSalaryDetails,
                JobDescription = job.JobDescription,
                CareerLevel = job.CareerLevel.ToString(),
                Categories = job.JobCategories?.Select(x=> x.Category)?.ToList(),
                CompanyName = job.Recruiter.CompanyName,
                WorkPlace = job.WorkPlace.ToString(),
                Country = job.Country,
                CreatedAt= job.CreatedAt,
                CreatedBy= job.CreatedBy,
                HideSalary= job.HideSalary,
                Id = jobPostId,
                JobTypes = job.JobTypes?.Select(x=> x.Type.ToString())?.ToList(),
                MaxSalaryRange = job.MaxSalaryRange,
                MaxYearsOfExperince = job.MaxYearsOfExperince,
                MinSalaryRange = job.MinSalaryRange,
                MinYearsOfExperince = job.MinYearsOfExperince,
                NumberOfVecancy = job.NumberOfVecancy,
                RecruiterId = job.RecruiterId,
                Status = job.Status.ToString(),
                Title = job.Title,
            }, canApplicantApplay);
        }

        public List<JobApplications>  GetRecruiterJobsApplications(string userId)
        {
           return _jobPostRepository.GetDetailedJobsByUserId(userId).Select(x=> new JobApplications
           {
               Title = x.Title,
               JobTypes = x.JobTypes?.Select(j => j.Type.ToString())?.ToList(),
               Status = x.Status.ToString(),
               MaxSalaryRange = x.MaxSalaryRange,
               MaxYearsOfExperince = x.MaxYearsOfExperince,
               MinSalaryRange = x.MinSalaryRange,
               MinYearsOfExperince = x.MinYearsOfExperince,
               NumberOfVecancy = x.NumberOfVecancy,
               WorkPlace = x.WorkPlace.ToString(),
               JobDescription = x.JobDescription,
               CareerLevel = x.CareerLevel.ToString(),
               Categories = x.JobCategories?.Select(x => x.Category)?.ToList(),
               Country = x.Country,
               CreatedAt = x.CreatedAt,
               JobId= x.Id,
               Applicants = x.ApplicantJobs?.Select(y=> new LookUpDTO
               {
                   Id =y.ApplicantId,
                   Name =$"{y.Applicant.User.FirstName} {y.Applicant.User.LastName}"
              }).ToList(),
           }).ToList();
        }
  
        
        private IEnumerable<Job> GetMatchedJobsForApplicant(IEnumerable<Job> jobs, Applicant user)
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

        private IEnumerable<Job> GetFilteredJobs(ApplicantJobFilterDTO filter, IEnumerable<Job> jobs)
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
                JobTypes = x.JobTypes?.Select(j => j.Type.ToString())?.ToList(),
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
                Categories = x.JobCategories?.Select(x=> x.Category)?.ToList(),
                Country = x.Country,
                HideSalary = x.HideSalary,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                
            }).ToList();
        }

        public bool Delete(int jobId)
        {
            return _jobPostRepository.Delete(jobId);
        }

        public JobDTO Edit(EditJobDTO dto)
        {
            Job job = _applicantJobRepository.GetJobById(dto.Id);
            if (job == null) return null;
            
            job.Title = dto.Title;
            job.Country = dto.Country;
            job.WorkPlace = dto.WorkPlace;
            job.CareerLevel = dto.CareerLevel;
            job.MinYearsOfExperince = dto.MinYearsOfExperince;
            job.MaxYearsOfExperince = dto.MaxYearsOfExperince;
            job.MaxSalaryRange = dto.MaxSalaryRange;
            job.MinSalaryRange = dto.MinSalaryRange;
            job.HideSalary = dto.HideSalary;
            job.AdditinalSalaryDetails = dto.AdditinalSalaryDetails;
            job.NumberOfVecancy = dto.NumberOfVecancy;
            job.JobDescription = dto.JobDescription;

            job.JobCategories?.Clear();
            if (job.JobCategories is null) job.JobCategories = new List<JobCategory>();
            job.JobCategories.AddRange(dto.Categories.Select(x => new JobCategory { Category = x, JobId = job.Id }));

            job.JobTypes?.Clear();
            if (job.JobTypes is null) job.JobTypes = new List<JobType>();
            job.JobTypes.AddRange(dto.JobTypes.Select(x => new JobType { Type = x, JobId = job.Id }));

            Job updatedJob = _jobPostRepository.Update(job);
            return new JobDTO
            {
                Id = updatedJob.Id,
                Title = updatedJob?.Title,
                JobTypes = updatedJob?.JobTypes?.Select(j => j.Type.ToString())?.ToList(),
                Status = updatedJob?.Status.ToString(),
                MaxSalaryRange = updatedJob?.MaxSalaryRange,
                MaxYearsOfExperince = updatedJob?.MaxYearsOfExperince,
                MinSalaryRange = updatedJob?.MinSalaryRange,
                MinYearsOfExperince = updatedJob?.MinYearsOfExperince,
                NumberOfVecancy = updatedJob?.NumberOfVecancy,
                RecruiterId = updatedJob?.RecruiterId,
                CompanyName = updatedJob?.Recruiter.CompanyName,
                WorkPlace = updatedJob?.WorkPlace.ToString(),
                AdditinalSalaryDetails = updatedJob?.AdditinalSalaryDetails,
                JobDescription = updatedJob?.JobDescription,
                CareerLevel = updatedJob?.CareerLevel.ToString(),
                Categories = updatedJob?.JobCategories?.Select(x => x.Category)?.ToList(),
                Country = updatedJob?.Country,
                HideSalary = updatedJob?.HideSalary,
                CreatedAt = updatedJob.CreatedAt,
                CreatedBy = updatedJob?.CreatedBy,
            };
        }
    }
}
