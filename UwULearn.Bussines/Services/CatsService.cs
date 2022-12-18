using UwULearn.Bussines.Exceptions;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Enums;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class CatsService : ICatsService
{
    private readonly ICatsRepository _catsRepository;
    private readonly ISkinsService _skinsService;

    public CatsService(ICatsRepository catsRepository, ISkinsService skinsService)
    {
        _catsRepository = catsRepository;
        _skinsService = skinsService;
    }

    public async Task ChangeSkin(Cat cat)
    {
        await _catsRepository.ChangeSkin(cat);
    }

    public async Task<int> CreateCat(Cat cat)
    {
        cat.Skin = await _skinsService.GetDeafaultSkin();
        return await _catsRepository.CreateCat(cat);
    }

    public async Task<Cat> GetCat(int catId)
    {
        return await _catsRepository.GetCat(catId);
    }

    public async Task<int> GetHealth(int catId)
    {
        var cat = await _catsRepository.GetCat(catId);

        if (cat is null)
            throw new NotFoundException("Такого котика не существует");

        return cat.Health;
    }

    public async Task HealthUpdate(int catId, int newHealth)
    {
        var cat = await _catsRepository.GetCat(catId);

        if (cat is null)
            throw new NotFoundException("Такого котика не существует");

        cat.Health = newHealth;
        await _catsRepository.HealthUpdate(cat);
    }

    public async Task Rename(int catId, string newName)
    {
        var cat = await _catsRepository.GetCat(catId);

        if (cat is null)
            throw new NotFoundException("Такого котика не существует");

        cat.Name = newName;
        await _catsRepository.HealthUpdate(cat);
    }
}
