using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
  public class LookupRepository : ILookupRepository
  {

    private readonly DatabaseContext _context;

    public LookupRepository(DatabaseContext context)
    {
      _context = context;
    }

    public List<Qualifications> GetAllQualification()
    {
      var results = (from qualification in _context.Qualifications
                     select qualification).ToList();

      return results;
    }

    public List<Provinces> GetAllProvinces()
    {
      var results = (from province in _context.Provinces
                     select province).ToList();

      return results;
    }

    public List<ExperienceYears> GetAllExperienceYears()
    {
      var results = (from experienceYears in _context.ExperienceYears
                     select experienceYears).ToList();

      return results;
    }

    public List<BusinessUnit> GetAlBusinessUnits()
    {
      var results = (from businessUnits in _context.BusinessUnits
                     select businessUnits).ToList();

      return results;
    }
  }
}
