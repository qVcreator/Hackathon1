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

    public Task Add(Course newCourse)
    {
        throw new NotImplementedException();
    }

    public Task AddLesson(Lesson newLesson)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLesson(int lessonId)
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

    public Task Update(Course updatedCourse)
    {
        throw new NotImplementedException();
    }
}
