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
    private readonly IUsersService _usersService;

    public CatsService(ICatsRepository catsRepository, ISkinsService skinsService, IUsersService usersService)
    {
        _catsRepository = catsRepository;
        _skinsService = skinsService;
        _usersService = usersService;
    }

    public async Task ChangeSkin(int skinId, int userId)
    {
        var skin = await _skinsService.GetSkin(skinId);
        var user = await _usersService.GetUserById(userId);

        if (skin is null)
            throw new NotFoundException("Такого скина нет");

        if (skin is null)
            throw new NotFoundException("Такого пользователя нет");

        if(user.Role != Role.Admin)
        {
            if (user.Energy < skin.Cost)
                throw new NotEnoughEnergyException("Недостаточно Энергии");
            else
                user.Energy -= skin.Cost;
        }

        user.Cat.Skin = skin;
        await _catsRepository.ChangeSkin(user.Cat);
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
