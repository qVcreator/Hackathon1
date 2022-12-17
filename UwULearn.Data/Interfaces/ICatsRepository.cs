using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ICatsRepository
{
    public Task<string> Rename(int catId, string newName);
    public Task HealthUpdate(int catId, int newHealth);
    public Task<int> GetHealth(int catId);
    public Task<int> CreateCat(Cat newCat);
}