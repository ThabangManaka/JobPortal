using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ApplicantDetailRepository : IApplicantDetailRepository
    {
        private readonly DatabaseContext _context;

        public ApplicantDetailRepository(DatabaseContext context)
        {
            _context = context;
        }


        public bool AddApplicantDetail(ApplicantDetail applicantDetail)
        {
            try
            {
                
                _context.ApplicantDetails.Add(applicantDetail);

                // Save changes to the database
                var results = _context.SaveChanges();

                // Return true if one or more rows were affected
                return results > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (optional: replace this with proper logging)
                Console.WriteLine($"An error occurred while adding applicant detail: {ex.Message}");

                // Return false to indicate failure
                return false;
            }
        }

        public List<ApplicantDetail> GetAllApplicantDetail()
        {
            var results = (from applicantDetail in _context.ApplicantDetails
                           select applicantDetail).ToList();

            return results;
        }


    }
}
