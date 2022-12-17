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

    public Task<int> AddSkin(Skin newSkin)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSkin(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Skin> GetSkin(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSkin()
    {
        throw new NotImplementedException();
    }
}
