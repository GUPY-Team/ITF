// using Duende.IdentityServer.Services;
// using IdentityServer.Common;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc.RazorPages;
//
// namespace IdentityServer.Pages.Error;
//
// [AllowAnonymous]
// [SecurityHeaders]
// public class IndexModel : PageModel
// {
//     private readonly IIdentityServerInteractionService _interaction;
//     private readonly IWebHostEnvironment _environment;
//         
//     public ErrorViewModel ErrorView { get; set; }
//         
//     public IndexModel(IIdentityServerInteractionService interaction, IWebHostEnvironment environment)
//     {
//         _interaction = interaction;
//         _environment = environment;
//     }
//         
//     public async Task OnGet(string errorId)
//     {
//         ErrorView = new ErrorViewModel();
//
//         // retrieve error details from identityserver
//         var message = await _interaction.GetErrorContextAsync(errorId);
//         if (message != null)
//         {
//             ErrorView.Error = message;
//
//             if (!_environment.IsDevelopment())
//             {
//                 // only show in development
//                 message.ErrorDescription = null;
//             }
//         }
//     }
// }