namespace Interfaces
{
    public interface IUnitOfWork
    {


        Task<bool> SaveAsync();
        IJobPostRepository JobPostRepository { get; }   
        IUserRepository UserRepository { get; }
        IApplicantRepository ApplicantRepository { get; }
        ILookupRepository LookupRepository { get; }
  }
}
