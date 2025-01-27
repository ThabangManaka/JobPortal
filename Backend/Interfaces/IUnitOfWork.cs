namespace Interfaces
{
    public interface IUnitOfWork
    {


        Task<bool> SaveAsync();
        IJobPostRepository JobPostRepository { get; }   
    }
}
