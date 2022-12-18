using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface ICatsService
{
    public Task<int> CreateCat(Cat cat);
    public Task Rename(int catId, string newName);
    public Task HealthUpdate(int catId, int newHealth);
    public Task<int> GetHealth(int catId);
    public Task<Cat> GetCat(int catId);
}
