using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ICoursesRepository
{
    public Task AddLesson(Course course);
    public Task DeleteLesson(Course course);
    public Task Update(Course updatedCourse);
    public Task<int> Add(Course newCourse);
    public Task<Course> Get(int courseId);
    public Task<List<Course>> GetAll();
}