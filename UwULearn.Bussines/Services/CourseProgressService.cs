using UwULearn.Bussines.Exceptions;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CourseProgressService : ICourseProgressService
{
    private readonly ICourseProgressRepository _courseProgressRepository;
    private readonly IUsersService _usersService;

    public CourseProgressService(ICourseProgressRepository courseProgressRepository, IUsersService usersService)
    {
        _courseProgressRepository = courseProgressRepository;
        _usersService = usersService;
    }

    public async Task<List<User>> GetLeaderBoardTopTen()
    {
        return await _courseProgressRepository.GetLeaderBoardTopTen();
    }

    public async Task<CourseProgress> GetProgressByUserId(int userId)
    {
        if (await _usersService.GetUserById(userId) == default)
            throw new NotFoundException("такого пользователя нет");

        return await _courseProgressRepository.GetProgressByUserId(userId);
    }
}
