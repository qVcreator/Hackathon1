using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ILessonsRepository
{
    public Task<int> CreateLesson(Lesson newLesson);
    public Task UpdateLesson(Lesson newLesson);
    public Task DeleteLesson(int lessonId);
}
