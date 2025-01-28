using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public  class JobPostRepository : IJobPostRepository
    {

        private readonly DatabaseContext _context;

        public JobPostRepository(DatabaseContext context) {
          _context = context;
        }

        public bool AddJobPost(JobPosts jobPosts)
        {
             _context.JobPosts.Add(jobPosts);    

            var results = _context.SaveChanges(); 
            if(results >0)
            {
                return true;    
            }
            else
            {
                return false;

            }

        }

        public List<JobPosts> GetAllJobPost()
        {
          var results = (from jobPost in _context.JobPosts  
                         select jobPost).ToList();

            return results;
        }
    }
}
