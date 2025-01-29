using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
  public interface ILookupRepository
  {
    List<BusinessUnit> GetAlBusinessUnits();
    List<ExperienceYears> GetAllExperienceYears();
    List<Provinces> GetAllProvinces();
    List<Qualifications> GetAllQualification();
  }
}
