using UwULearn.Data.Entities;

namespace UwULearn.Data.Interfaces;

public interface ICatsRepository
{
    public Task Rename(Cat cat);
    public Task HealthUpdate(Cat cat);
    public Task<int> GetHealth(int catId);
    public Task<int> CreateCat(Cat newCat);
    public Task<Cat> GetCat(int catId);
    public Task ChangeSkin(Cat cat);
}