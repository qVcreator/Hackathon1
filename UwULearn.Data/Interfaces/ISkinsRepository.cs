using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ISkinsRepository
{
    public Task<Skin> GetSkin(int id);
    public Task<int> AddSkin(Skin newSkin);
    public Task DeleteSkin(int id);
    public Task UpdateSkin();
}
