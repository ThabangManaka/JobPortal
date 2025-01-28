using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IApplicantRepository
    {
        bool AddApplicantDetail(ApplicantDetail applicantDetail);
        List<ApplicantDetail> GetAllApplicantDetail();
    }
}
