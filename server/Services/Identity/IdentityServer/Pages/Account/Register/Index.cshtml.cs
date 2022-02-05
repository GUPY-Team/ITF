using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Services;
using IdentityServer.Common;
using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Account.Register;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IIdentityServerInteractionService _interaction;

    public IndexModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IIdentityServerInteractionService interaction)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _interaction = interaction;
    }

    [BindProperty]
    public RegisterModel RegisterModel { get; set; }

    public IActionResult OnGet(string returnUrl)
    {
        if (HttpContext.User.IsAuthenticated())
        {
            return Redirect("~/");
        }
        
        RegisterModel = new RegisterModel
        {
            ReturnUrl = returnUrl
        };

        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new ApplicationUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = RegisterModel.Username
        };

        var signUpResult = await _userManager.CreateAsync(user, RegisterModel.Password);
        if (!signUpResult.Succeeded)
        {
            foreach (var error in signUpResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return Page();
        }

        await _signInManager.SignInAsync(user, true);

        var context = await _interaction.GetAuthorizationContextAsync(RegisterModel.ReturnUrl);
        if (context != null)
        {
            return context.IsNativeClient() 
                ? this.LoadingPage(RegisterModel.ReturnUrl) 
                : Redirect(RegisterModel.ReturnUrl);
        }

        if (Url.IsLocalUrl(RegisterModel.ReturnUrl))
        {
            return Redirect(RegisterModel.ReturnUrl);
        }

        if (string.IsNullOrEmpty(RegisterModel.ReturnUrl))
        {
            return Redirect("~/");
        }

        throw new Exception("invalid return URL");
    }
}