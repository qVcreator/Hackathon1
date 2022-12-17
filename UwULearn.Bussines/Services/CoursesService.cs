using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CoursesService : ICoursesService
{
    private readonly ICoursesRepository _coursesRepository;

    public CoursesService(ICoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }

    public Task<int> Add(Course newCourse)
    {
        throw new NotImplementedException();
    }

    public Task AddLesson(int courseId, int lessonId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLesson(int courseId, int lessonId)
    {
        throw new NotImplementedException();
    }

    public Task<Course> Get(int courseId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Course>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Course updatedCourse)
    {
        throw new NotImplementedException();
    }
}
