using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class LessonsService : ILessonsService
{
    private readonly ILessonsRepository _lessonsRepository;

    public LessonsService(ILessonsRepository lessonsRepository)
    {
        _lessonsRepository = lessonsRepository;
    }

    public Task<int> CreateLesson(Lesson newLesson)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLesson(int lessonId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLesson(int id, Lesson newLesson)
    {
        throw new NotImplementedException();
    }
}
