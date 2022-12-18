using UwULearn.Bussines.Exceptions;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class LessonsService : ILessonsService
{
    private readonly ILessonsRepository _lessonsRepository;
    private readonly IUsersService _usersService;

    public LessonsService(ILessonsRepository lessonsRepository, IUsersService usersService)
    {
        _lessonsRepository = lessonsRepository;
        _usersService = usersService;
    }

    public async Task<int> CreateLesson(Lesson newLesson)
    {
        return await _lessonsRepository.CreateLesson(newLesson);
    }

    public Task DeleteLesson(int lessonId)
    {
        throw new NotImplementedException();
    }

    public async Task EditTask(int lessonId, TaskEntity editedTask)
    {
        var lesson = await _lessonsRepository.GetLessonById(lessonId);

        lesson.Task.Example = editedTask.Example;
        lesson.Task.Descriotion = editedTask.Descriotion;
        lesson.Task.Example = editedTask.Example;
        lesson.Task.Reward = editedTask.Reward;

        await _lessonsRepository.EditTask(lesson);
    }

    public async Task<List<Lesson>> GetLessons()
    {
        return await _lessonsRepository.GetLessons();
    }

    public async Task<int> CheckAnswer(int lessonId, int userId, string userAnswer)
    {
        var lesson = await _lessonsRepository.GetLessonById(lessonId);
        var user = await _usersService.GetUserById(userId);

        if (lesson == default)
            throw new NotFoundException("такого урока нет");

        if(lesson.Task.CorrectAnswer == userAnswer)
        {
            user.Energy += lesson.Task.Reward;
            await _usersService.UpdateEnergy(user);
        }

        return user.Energy;
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
