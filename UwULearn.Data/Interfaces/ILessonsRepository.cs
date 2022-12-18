using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ILessonsRepository
{
    public Task<int> CreateLesson(Lesson newLesson);
    public Task UpdateLesson(Lesson newLesson);
    public Task DeleteLesson(int lessonId);
    public Task<List<Lesson>> GetLessons();
    public Task<Lesson> GetLessonById(int id);
    public Task EditTask(Lesson lesson);
    
}
