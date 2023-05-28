using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Objects;

namespace WebApplication1.Helpers.Services;

public class AdminServices
{
    private readonly UserManager<UserEntity> _userManager;

    public AdminServices(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

   

    public async Task<IEnumerable<UserObject>> GetUserAsync()
    {
        var users = new List<UserObject>();
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            var _user = new UserObject
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!
            };
            users.Add(_user);

            foreach (var roll in await _userManager.GetRolesAsync(user))
            {
                _user.RoleName.Add(roll);
            }
        }
        return users;
    }
}
