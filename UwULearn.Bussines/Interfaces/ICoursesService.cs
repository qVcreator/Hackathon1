using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ICoursesService
{
    public Task AddLesson(int courseId, int lessonId);
    public Task DeleteLesson(int courseId, int lessonId);
    public Task Update(int id, Course updatedCourse);
    public Task<int> Add(Course newCourse);
    public Task<Course> Get(int courseId);
    public Task<List<Course>> GetAll();
}
