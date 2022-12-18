using UwULearn.Data.Entities;
using UwULearn.Data.Models;

namespace UwULearn.Bussines.Interfaces;

public interface IUsersService
{
    public Task<int> AddUser(User user);
    public Task ChangePassword(UpdatePasswordModel updatePasswordModel); 
    public Task ChangeCatsSkin(int userId, int skinId);
    public Task AddCourse(int userId, int courseId);
    public Task RemoveCourse(int userId, int courseId);
}
