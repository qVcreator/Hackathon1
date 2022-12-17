using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class LessonsRepository : ILessonsRepository
{
    private readonly UwuLearnContext _context;

    public LessonsRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public Task<int> CreateLesson(Lesson newLesson)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLesson(int lessonId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLesson(Lesson newLesson)
    {
        throw new NotImplementedException();
    }
}
