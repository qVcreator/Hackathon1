using UwULearn.Data.Entities;

namespace UwULearn.Bussines.Interfaces;

public interface IAuthService
{
    public string GetToken(User user);
    public Task<User> GetUserToLogin(string username, string password);
}
