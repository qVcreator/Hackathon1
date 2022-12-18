using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CatsService : ICatsService
{
    private readonly ICatsRepository _catsRepository;

    public CatsService(ICatsRepository catsRepository)
    {
        _catsRepository = catsRepository;
    }

    public async Task<int> CreateCat(Cat cat)
    {
        return await _catsRepository.CreateCat(cat);
    }

    public async Task<Cat> GetCat(int catId)
    {
        return await _catsRepository.GetCat(catId);
    }

    public Task<int> GetHealth(int catId)
    {
        throw new NotImplementedException();
    }

    public Task HealthUpdate(int catId, int newHealth)
    {
        throw new NotImplementedException();
    }

    public Task Rename(int catId, string newName)
    {
        throw new NotImplementedException();
    }
}
