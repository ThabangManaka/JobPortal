using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Qualifications> Qualifications { get; set; }
        public DbSet<ExperienceYears> ExperienceYears { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<JobPosts> JobPosts { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
