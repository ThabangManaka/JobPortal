using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;


        public ApplicantController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        [HttpPost("NewApplication")]
        public async Task<IActionResult> NewApplication([FromBody] ApplicantDetailDto applicantDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var applicantDetail = mapper.Map<ApplicantDetail>(applicantDetailDto);
            uow.ApplicantRepository.AddApplicantDetail(applicantDetail);
            await uow.SaveAsync();
            return Ok(201);

        }

        [HttpGet("GetAll")]
        public List<ApplicantDetail> GetAll()
        {
            return uow.ApplicantRepository.GetAllApplicantDetail();
        }
    }
}
