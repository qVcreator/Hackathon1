using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UwuLearnContext _context;

    public UsersRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public async Task AddCourse(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> Adduser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public Task ChangePassword()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users
            .Include(u => u.Courses)
            .Include(u => u.Cat)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _context.Users
            .Include(u => u.Courses)
            .Include(u => u.Cat)
            .FirstOrDefaultAsync(q => q.Username == username);
    }

    public async Task<bool> IsUserExist(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user == default)
            return false;
        else
            return true;
    }

    public Task RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEnergyAfterTransaction(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
