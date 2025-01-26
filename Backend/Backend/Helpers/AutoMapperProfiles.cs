using AutoMapper;
using Dto;
using Models;

namespace Backend.Helpers
{
    public class AutoMapperProfiles  : Profile
    {
        public AutoMapperProfiles() {


            CreateMap<JobPosts, JobPostsDto>().ReverseMap();
        } 
    }
}
