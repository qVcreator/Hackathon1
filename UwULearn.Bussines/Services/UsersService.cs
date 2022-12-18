using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Interfaces;
using UwULearn.Data.Models;

namespace UwULearn.Bussines.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task AddCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public Task ChangeCatsSkin(int userId, int skinId)
    {
        throw new NotImplementedException();
    }

    public Task ChangePassword(UpdatePasswordModel updatePasswordModel)
    {
        throw new NotImplementedException();
    }

    public Task RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }
}
