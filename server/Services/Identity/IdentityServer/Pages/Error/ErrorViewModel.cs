using Duende.IdentityServer.Models;

namespace IdentityServer.Pages.Error;

public class ErrorViewModel
{
    public ErrorViewModel()
    {
    }

    public ErrorViewModel(string error)
    {
        Error = new ErrorMessage { Error = error };
    }

    public ErrorMessage Error { get; set; }
}