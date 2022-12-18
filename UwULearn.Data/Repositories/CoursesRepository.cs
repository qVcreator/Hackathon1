using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly UwuLearnContext _context;

    public CoursesRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Course newCourse)
    {
        await _context.Courses.AddAsync(newCourse);
        await _context.SaveChangesAsync();
        return newCourse.Id;
    }

    public async Task AddLesson(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLesson(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }

    public async Task<Course> Get(int courseId)
    {
        return await _context.Courses
            .Include(c => c.Lessons)
            .FirstOrDefaultAsync(q => q.Id == courseId);
    }

    public async Task<List<Course>> GetAll()
    {
        return await _context.Courses
            .Include(c => c.Lessons)
            .ToListAsync();
    }

    public async Task Update(Course updatedCourse)
    {
        _context.Courses.Update(updatedCourse);
        await _context.SaveChangesAsync();
    }
}
