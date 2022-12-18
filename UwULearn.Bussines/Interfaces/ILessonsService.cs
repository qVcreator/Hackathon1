using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ILessonsService
{
    public Task<int> CreateLesson(Lesson newLesson);
    public Task UpdateLesson(int id, Lesson newLesson);
    public Task DeleteLesson(int lessonId);
    public Task<List<Lesson>> GetLessons();
    public Task EditTask(int lessonId, TaskEntity task);
    public Task<int> CheckAnswer(int lessonId, int userId,string userAnswer);
}
