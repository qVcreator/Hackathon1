using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ICoursesRepository
{
    public Task AddLesson(Lesson newLesson);
    public Task DeleteLesson(int lessonId);
    public Task Update(Course updatedCourse);
    public Task Add(Course newCourse);
    public Task<Course> Get(int courseId);
    public Task<List<Course>> GetAll();
}