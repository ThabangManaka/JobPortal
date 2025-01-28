using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IJobPostRepository
    {
        bool AddJobPost(JobPosts jobPosts);

        List<JobPosts> GetAllJobPost();
    }
}
