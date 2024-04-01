using BookApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


namespace BookApplication.Business_Layer
{
    public class AccountFacade : IAccountFacade
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountFacade(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public async Task<SignInResult> Signin(User obj)
        {
            var result = await _signInManager.PasswordSignInAsync(obj.Email, obj.Password, false, false);
            if (result.Succeeded)
            {
                return result;
            }
            return SignInResult.Failed;

        }

    }
}