using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public void AddCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public void ChangeCatsSkin(int userId, int skinId)
    {
        throw new NotImplementedException();
    }

    public void ChangePassword()
    {
        throw new NotImplementedException();
    }

    public void RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }
}
