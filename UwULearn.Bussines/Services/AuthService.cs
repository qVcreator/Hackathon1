using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UwULearn.Bussines.Interfaces;
using UwULearn.Data.Entities;
using UwULearn.Data.Interfaces;

namespace UwULearn.Bussines.Services;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;

    public AuthService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public string GetToken(User user)
    {
        if (user is null || user.Username is null)
        {
            throw new Exception();
        }
        Claim idClaim = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username), { new Claim(ClaimTypes.Role, user.Role.ToString()) }, idClaim };

        var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<User> GetUserToLogin(string username, string password)
    {
        User result = null!;

        var user = await _usersRepository.GetUserByUsername(username);

        if(user.Password == password)
            result = user;

        return result!;
    }
}
