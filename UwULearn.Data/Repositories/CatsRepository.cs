using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class CatsRepository : ICatsRepository
{
    private readonly UwuLearnContext _context;

    public CatsRepository(UwuLearnContext context)
    {
        _context = context;
    }   

    public async Task<int> CreateCat(Cat newCat)
    {
        await _context.Cats.AddAsync(newCat);
        await _context.SaveChangesAsync();
        return newCat.Id;
    }

    public async Task<Cat> GetCat(int catId)
    {
        return await _context.Cats.FirstOrDefaultAsync(q => q.Id == catId);
    }

    public Task<int> GetHealth(int catId)
    {
        throw new NotImplementedException();
    }

    public Task HealthUpdate(int catId, int newHealth)
    {
        throw new NotImplementedException();
    }

    public Task<string> Rename(int catId, string newName)
    {
        throw new NotImplementedException();
    }
}
