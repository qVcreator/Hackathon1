using UwULearn.Bussines.Models;
using UwULearn.Data.Entities;
using UwULearn.Data.Models;

namespace UwULearn.Bussines.Interfaces;

public interface IUsersService
{
    public Task<int> AddUser(User user);
    public Task<int> AddAdmin(AddAdminModel admin);
    public Task ChangePassword(UpdatePasswordModel updatePasswordModel); 
    public Task AddCourse(int userId, int courseId);
    public Task RemoveCourse(int userId, int courseId);
    public Task<User> GetUserById(int id);
}
