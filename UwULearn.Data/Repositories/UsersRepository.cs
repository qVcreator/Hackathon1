using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UwuLearnContext _context;

    public UsersRepository(UwuLearnContext context)
    {
        _context = context;
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
