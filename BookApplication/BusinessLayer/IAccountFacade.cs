using BookApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BookApplication.Business_Layer
{
    public interface IAccountFacade
    {
        public Task<Microsoft.AspNetCore.Identity.SignInResult> Signin(User obj);
    }
}