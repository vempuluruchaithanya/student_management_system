using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
