using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Helpers.Services
{
    public class AccountServices
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AddressServices _addressServices;

        public AccountServices(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressServices addressServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _addressServices = addressServices;
        }
        public async Task<bool> SignUpAsync(RegisterViewModel model)
        {
            try
            {
                //Create user
                string rollName = "User";
                if (!await _userManager.Users.AnyAsync())
                {
                    rollName = "Admin";
                }
                UserEntity userEntity = model;
                var result = await _userManager.CreateAsync(userEntity, model.Password);
                //Create address
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userEntity, rollName);
                    var address = await _addressServices.GetOrCreateAsync(model);
                    var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                    //Add address to user
                    if (user != null) 
                    {
                        var userAddress = await _addressServices.AddUserAddressAsync(user, address);
                        return userAddress;
                    }
                    
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        public async Task<bool> SignInAsync(SignInViewModel model)
        {
            try
            {
                var userEntity = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (userEntity != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(userEntity, model.Password, model.RememberMe, false);
                    return result.Succeeded;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        /*
        public async Task<bool> SignOutAsync()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }
        */
    }
}


