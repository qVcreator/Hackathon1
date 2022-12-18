using Microsoft.EntityFrameworkCore;
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

    public async Task<int> CreateLesson(Lesson newLesson)
    {
        await _context.Lessons.AddAsync(newLesson);
        await _context.SaveChangesAsync();
        return newLesson.Id;
    }

    public Task DeleteLesson(int lessonId)
    {
        throw new NotImplementedException();
    }

    public async Task EditTask(Lesson lesson)
    {
        _context.Update(lesson);
        await _context.SaveChangesAsync();
    }

    public async Task<Lesson> GetLessonById(int id)
    {
        return await _context.Lessons
            .Include(l => l.Task)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<Lesson>> GetLessons()
    {
        return await _context.Lessons
            .Include(l => l.Task)
            .ToListAsync();
    }

    public async Task UpdateLesson(Lesson newLesson)
    {
        _context.Update(newLesson);
        await _context.SaveChangesAsync();
    }
}
