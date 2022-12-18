using Microsoft.EntityFrameworkCore;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class SkinsRepository : ISkinsRepository
{
    private readonly UwuLearnContext _context;

    public SkinsRepository(UwuLearnContext context)
    {
        _context = context;
    }

    public async Task<Skin> GetDeafaultSkin()
    {
        var deafaultSkinId = 1;
        return await _context.Skins.FirstOrDefaultAsync(q => q.Id == deafaultSkinId);
    }
    public async Task<int> AddSkin(Skin newSkin)
    {
        await _context.Skins.AddAsync(newSkin);
        await _context.SaveChangesAsync();
        return newSkin.Id;
    }

    public Task DeleteSkin(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Skin> GetSkin(int id)
    {
        return await _context.Skins.FirstOrDefaultAsync(q => q.Id == id);
    }

    public Task UpdateSkin()
    {
        throw new NotImplementedException();
    }
}
