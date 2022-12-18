using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class CourseProgressRepository : ICourseProgressRepository
{
    private readonly UwuLearnContext _context;

    public CourseProgressRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetLeaderBoardTopTen()
    {
        return await _context.CourseProgresses
            .OrderByDescending(q => q.FinishedTasks.Count)
            .Take(10)
            .Select(q => q.User)
            .Include(u => u.Cat)
            .Include(u => u.Courses)
            .ToListAsync();
    }

    public async Task<CourseProgress> GetProgressByUserId(int userId)
    {
        return await _context.CourseProgresses.FirstOrDefaultAsync(q => q.User.Id == userId);
    }
}
