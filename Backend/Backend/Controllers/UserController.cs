using AutoMapper;
using Dto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UserController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpPost("Registers")]
        public async Task<ActionResult> Registers([FromBody] UsersDto usersDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userData = mapper.Map<Users>(usersDto);
            uow.UserRepository.Register(userData);
            await uow.SaveAsync();
            return Ok(201);

        }

    [HttpPost("GetUserById/{id}")]
    public async  Task<Users> GetUserById(int id)
        {

            try
            {

              return uow.UserRepository.GetUsersbyId(id);
            }
            catch (Exception)
            {
              throw;
            }

    } 

    }
}
