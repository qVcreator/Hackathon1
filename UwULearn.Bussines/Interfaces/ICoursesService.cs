using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ICoursesService
{
    public Task AddLesson(Lesson newLesson);
    public Task DeleteLesson(int lessonId);
    public Task Update(Course updatedCourse);
    public Task Add(Course newCourse);
    public Task<Course> Get(int courseId);
    public Task<List<Course>> GetAll();
}
