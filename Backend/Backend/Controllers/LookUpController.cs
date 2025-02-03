using AutoMapper;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LookUpController : Controller
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public LookUpController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet("GetAllQualifications")]
    public List<Qualifications> GetAllQualifications()
    {
      return uow.LookupRepository.GetAllQualification();
    }

    [HttpGet("GetAllProvinces")]
    public List<Provinces> GetAllProvinces()
    {
      return uow.LookupRepository.GetAllProvinces();
    }

    [HttpGet("GetAllBusinessUnits")]
    public List<BusinessUnit> GetAllBusinessUnits()
    {
      return uow.LookupRepository.GetAlBusinessUnits();
    }

    [HttpGet("GetAllExperienceYears")]
    public List<ExperienceYears> GetAllExperienceYears()
    {
      return uow.LookupRepository.GetAllExperienceYears();
    }
  }
}
