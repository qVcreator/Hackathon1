using UwULearn.Bussines.Exceptions;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CoursesService : ICoursesService
{
    private readonly ICoursesRepository _coursesRepository;

    public CoursesService(ICoursesRepository coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }

    public async Task<int> Add(Course newCourse)
    {
        return await _coursesRepository.Add(newCourse);

    }

    public async Task AddLesson(int courseId, Lesson lesson)
    {
        var course = await _coursesRepository.Get(courseId);

        course.Lessons.Add(lesson);

        await _coursesRepository.AddLesson(course);
    }

    public async Task DeleteLesson(int courseId, int lessonId)
    {
        var course = await _coursesRepository.Get(courseId);

        if (course == default)
            throw new NotFoundException("такого курса нет");

        course.Lessons.RemoveAt(course.Lessons.FindIndex(q => q.Id == lessonId));

        await _coursesRepository.DeleteLesson(course);
    }

    public async Task<Course> Get(int courseId)
    {
        return await _coursesRepository.Get(courseId);
    }

    public async Task<List<Course>> GetAll()
    {
        return await _coursesRepository.GetAll();
    }

    public async Task Update(int id, Course updatedCourse)
    {
        var course = await _coursesRepository.Get(id);

        if (course == default)
            throw new NotFoundException("такого курса нет");

        course.Description = updatedCourse.Description;
        course.Lessons = updatedCourse.Lessons;
        course.Name = updatedCourse.Name;

        await _coursesRepository.Update(course);
    }
}
