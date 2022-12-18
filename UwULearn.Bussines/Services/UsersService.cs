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

    public Task AddCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddUser(User user)
    {
        throw new NotImplementedException();
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

    public Task ChangeCatsSkin(int userId, int skinId)
    {
        throw new NotImplementedException();
    }

    public Task ChangePassword(UpdatePasswordModel updatePasswordModel)
    {
        throw new NotImplementedException();
    }

    public Task RemoveCourse(int userId, int courseId)
    {
        throw new NotImplementedException();
    }
}
