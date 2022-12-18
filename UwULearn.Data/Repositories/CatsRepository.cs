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
        return (await _context.Cats.FirstOrDefaultAsync(q => q.Id == catId))!;
    }

    public async Task<int> GetHealth(int catId)
    {
        var cat = await _context.Cats.FirstOrDefaultAsync(q => q.Id == catId);
        return cat!.Health;
    }

    public async Task HealthUpdate(int catId, int newHealth)
    {
        var cat = await _context.Cats.FirstOrDefaultAsync(q => q.Id == catId);
        cat!.Health = newHealth;
        _context.Cats.Update(cat);
        await _context.SaveChangesAsync();
    }

    public async Task Rename(int catId, string newName)
    {
        var cat = await _context.Cats.FirstOrDefaultAsync(q => q.Id == catId);
        cat!.Name = newName;
        _context.Cats.Update(cat);
        await _context.SaveChangesAsync();
    }
}
