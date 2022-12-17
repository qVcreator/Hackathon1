using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class SkinsService : ISkinsService
{
    private readonly ISkinsRepository _skinsRepository;

    public SkinsService(ISkinsRepository skinsRepository)
    {
        _skinsRepository = skinsRepository;
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
