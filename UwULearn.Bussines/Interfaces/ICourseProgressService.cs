using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ICourseProgressService
{
    public Task<List<User>> GetLeaderBoardTopTen();
    public Task<CourseProgress> GetProgressByUserId(int userId);
}
