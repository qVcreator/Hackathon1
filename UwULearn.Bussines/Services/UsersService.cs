using UwULearn.Bussines.Exceptions;
using UwULearn.Bussines.Interfaces;
using UwULearn.Bussines.Models;
using UwULearn.Data.Entities;
using UwULearn.Data.Enums;
using UwULearn.Data.Interfaces;
using UwULearn.Data.Models;

namespace UwULearn.Bussines.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IOrganizationService _organizationService;
    private readonly ICatsService _catsService;
    private readonly ISkinsService _skinsService;
    private readonly ICoursesService _coursesService;

    public UsersService(
        IUsersRepository usersRepository,
        IOrganizationService organizationService,
        ICatsService catsService,
        ISkinsService skinsService)
    {
        _usersRepository = usersRepository;
        _organizationService = organizationService;
        _catsService = catsService;
        _skinsService = skinsService;
    }

    public async Task ChangeCatSkin(int skinId, int userId)
    {
        var skin = await _skinsService.GetSkin(skinId);
        var user = await _usersRepository.GetUserById(userId);

        if (skin is null)
            throw new NotFoundException("Такого скина нет");

        if (skin is null)
            throw new NotFoundException("Такого пользователя нет");

        if (user.Role != Role.Admin)
        {
            if (user.Energy < skin.Cost)
                throw new NotEnoughEnergyException("Недостаточно Энергии");
            else
            {
                user.Energy -= skin.Cost;
                await _usersRepository.UpdateEnergyAfterTransaction(user);
            }
        }

        user.Cat.Skin = skin;
        await _catsService.ChangeSkin(user.Cat);
    }

    public async Task AddCourse(int userId, int courseId)
    {
        var user = await _usersRepository.GetUserById(userId);
        var course = await _coursesService.Get(courseId);

        if (course is null)
            throw new NotFoundException("Такого курса нет");

        if(!(user.Courses.Contains(course)))
            user.Courses.Add(course);

        await _usersRepository.AddCourse(user);
    }

    public async Task<int> AddUser(AddUserModel user)
    {
        if (await _usersRepository.IsUserExist(user.Username))
            throw new UserAlreadyExistException($"Пользователь с таким именем уже существует");

        var catId = await _catsService.CreateCat(new Cat
        {
            Health = 100,
            Name = user.CatName,
            Skin = await _skinsService.GetDeafaultSkin()
        });

        var cat = await _catsService.GetCat(catId);

        var newUser = new User()
        {
            Username = user.Username,
            Password = user.Password,
            Cat = cat,
            RegistrationDate = DateTime.UtcNow
        };

        return await _usersRepository.Adduser(newUser);
    }

    public async Task<int> AddAdmin(AddAdminModel admin)
    {
        var user = new User()
        {
            Username = admin.Username,
            Password = admin.Password,
            RegistrationDate = DateTime.Now,
            Role = Role.Admin
        };

        var organization = new Organization()
        {
            Name = admin.OrganizatonName,
            Collor = admin.OrganizatonCollor,
            Picture = admin.OrganizatonPicture,
            User = user
        };

        var cat = new Cat()
        {
            Health = 100,
            Name = admin.CatName,
            Skin = await _skinsService.GetDeafaultSkin()
        };

        var catId = await _catsService.CreateCat(cat);

        user.Cat = await _catsService.GetCat(catId);

        var userId = await _usersRepository.Adduser(user);
        await _organizationService.AddOrganization(organization);

        return userId;
    }

    public Task ChangePassword(UpdatePasswordModel updatePasswordModel)
    {
        throw new NotImplementedException();
    }

    public Task RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _usersRepository.GetUserById(id);
    }

    public async Task UpdateEnergy(User user)
    {
        await _usersRepository.UpdateEnergyAfterTransaction(user);
    }
}
