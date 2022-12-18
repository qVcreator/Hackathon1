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

    public Task AddCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
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
        return await _context.Users.FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(q => q.Username == username);
    }

    public Task RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEnergyAfterBuy(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
