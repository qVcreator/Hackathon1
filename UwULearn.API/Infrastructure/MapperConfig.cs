using AutoMapper;
using UwULearn.Data.Entities;
using UwULearn2.API.Models.Requests;
using UwULearn2.API.Models.Responses;

namespace UwULearn2.API.Infrastructure;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<UpdateCourseRequest, Course>();
        CreateMap<AddCourseRequest, Course>();
        CreateMap<Course, GetCourseAllInfoResponse>();
        CreateMap<Course, GetAllCoursesResponse>();
    }
}
