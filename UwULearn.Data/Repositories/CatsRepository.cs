using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Data.Repositories;

public class CatsRepository : ICatsRepository
{
    //private readonly UwuLearnContext

    public Task<int> CreateCat(Cat newCat)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetHealth(int catId)
    {
        throw new NotImplementedException();
    }

    public Task HealthUpdate(int catId, int newHealth)
    {
        throw new NotImplementedException();
    }

    public Task<string> Rename(int catId, string newName)
    {
        throw new NotImplementedException();
    }
}
