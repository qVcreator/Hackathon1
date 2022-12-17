using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ILessonsService
{
    public Task<int> CreateLesson(Lesson newLesson);
    public Task UpdateLesson(Lesson newLesson);
    public Task DeleteLesson(int lessonId);
}
