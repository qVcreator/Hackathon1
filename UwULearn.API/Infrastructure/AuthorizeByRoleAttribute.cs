using Microsoft.AspNetCore.Authorization;
using UwULearn.Data.Enums;

namespace UwULearn2.API.Infrastructure;

public class AuthorizeByRoleAttribute : AuthorizeAttribute
{
    public AuthorizeByRoleAttribute(params Role[] roles)
    {
        Roles = string.Join(",", roles);
    }
}
