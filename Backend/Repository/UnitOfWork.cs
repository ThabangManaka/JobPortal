using Interfaces;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
      public class UnitOfWork  : IUnitOfWork
    {

        private  readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
                
        }


        public IJobPostRepository JobPostRepository => new JobPostRepository(_context);
        public IUserRepository UserRepository => new UserRepository(_context);

        public IApplicantRepository ApplicantRepository => new ApplicantRepository(_context);
        public  async Task<bool> SaveAsync()
        {
          return  await _context.SaveChangesAsync()  > 0;  
        }
    }
}
