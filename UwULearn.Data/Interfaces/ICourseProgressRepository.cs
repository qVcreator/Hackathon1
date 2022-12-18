using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ICourseProgressRepository
{
    public Task<List<User>> GetLeaderBoardTopTen();
    public Task<CourseProgress> GetProgressByUserId(int userId);
}
