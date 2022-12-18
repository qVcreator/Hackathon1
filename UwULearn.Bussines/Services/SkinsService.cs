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

    public async Task<int> AddSkin(Skin newSkin)
    {
        return await _skinsRepository.AddSkin(newSkin);

    }

    public Task DeleteSkin(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Skin> GetDeafaultSkin()
    {
        return await _skinsRepository.GetDeafaultSkin();
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
