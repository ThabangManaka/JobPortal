using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : Controller
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public JobPostController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        [HttpPost("CreateJobPost")]
        public async Task<IActionResult> CreateJobPost([FromBody] JobPostsDto jobPostsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

 
            var jobPost = mapper.Map<JobPosts>(jobPostsDto);
             uow.JobPostRepository.AddJobPost(jobPost);
            await  uow.SaveAsync(); 
            return Ok(201);

        }


        [HttpGet("GetAll")]
        public List<JobPosts> GetAll()
        {
           return uow.JobPostRepository.GetAllJobPost();
        }

    }
}
