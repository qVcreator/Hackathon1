using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ISkinsService
{
    public Task<Skin> GetSkin(int id);
    public Task<int> AddSkin(Skin newSkin);
    public Task DeleteSkin(int id);
    public Task UpdateSkin();
}
