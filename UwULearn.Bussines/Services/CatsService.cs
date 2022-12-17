using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CatsService : ICatsService
{
    private readonly ICatsRepository _catsRepository;

    public CatsService(ICatsRepository catsRepository)
    {
        _catsRepository = catsRepository;
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
