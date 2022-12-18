using UwULearn.Bussines.Exceptions;
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

    public async Task<int> CreateLesson(Lesson newLesson)
    {
        return await _lessonsRepository.CreateLesson(newLesson);
    }

    public Task DeleteLesson(int lessonId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Lesson>> GetLessons()
    {
        return await _lessonsRepository.GetLessons();
    }

    public async Task UpdateLesson(int id, Lesson newLesson)
    {
        var lesson = await _lessonsRepository.GetLessonById(id);

        if (lesson == default)
            throw new NotFoundException("такого урока нет");

        lesson.Text = newLesson.Text;
        lesson.Description = newLesson.Description;
        lesson.Name = newLesson.Name;
        lesson.Video = newLesson.Video;

        await _lessonsRepository.UpdateLesson(lesson);
    }
}
