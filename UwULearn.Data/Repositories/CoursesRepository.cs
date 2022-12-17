using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly UwuLearnContext _context;

    public CoursesRepository(UwuLearnContext context)
    {
        _context = context;
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
