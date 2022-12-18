using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface IUsersRepository
{
    public Task<User> GetUserByUsername(string username);
    public Task ChangePassword(); //There is should be update model as param
    public Task ChangeCatsSkin(int userId, int skinId);
    public Task AddCourse(int userId, int courseId);
    public Task RemoveCourse(int userId, int courseId);
}