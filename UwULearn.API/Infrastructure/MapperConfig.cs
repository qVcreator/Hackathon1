using AutoMapper;
using UwULearn.Bussines.Models;
using UwULearn.Data.Entities;
using UwULearn.Data.Models;
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
        CreateMap<UpdatePasswordRequest, UpdatePasswordModel>();
        CreateMap<AddLessonRequest, Lesson>();
        CreateMap<UpdateLessonRequest, Lesson>();
        CreateMap<Skin, SkinResponse>();
        CreateMap<AddSkinRequest, Skin>();
        CreateMap<AddAdminRequest, AddAdminModel>();
        CreateMap<AddCatRequest, Cat>();
        CreateMap<Cat, CatResponse>();
        CreateMap<TaskEntity, TaskResponse>();
        CreateMap<Lesson, LessonResponse>();
        CreateMap<Course, CourseResponse>();
        CreateMap<CourseProgress, CourseProgressResponse>();
        CreateMap<AddUserRequest, AddUserModel>();
        CreateMap<TaskRequest, TaskEntity>();
        CreateMap<User, UsersResponse>();

        CreateMap<User, UserResponse>()
            .ForMember(dest => dest.FriendList, opt => opt.Ignore());
        CreateMap<AddAllChatMessageRequest, AllChatMessage>()
            .ForPath(dest => dest.From.Id, opt => opt.MapFrom(src => src.From));
        CreateMap<AllChatMessage, AllChatMessageResponse>()
            .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.From.Username));
    }
}
