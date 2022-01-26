namespace IdentityServerHost.Pages.Login;

public class LoginViewModel
{
    public bool AllowRememberLogin { get; set; } = true;
    public bool EnableLocalLogin { get; set; } = true;

    public IEnumerable<ExternalProviderViewModel> ExternalProviders { get; set; } = Array.Empty<ExternalProviderViewModel>();

    public IEnumerable<ExternalProviderViewModel> VisibleExternalProviders =>
        ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName));

    public bool IsExternalLoginOnly => EnableLocalLogin == false &&
                                       ExternalProviders?.Count() == 1;

    public string ExternalLoginScheme => IsExternalLoginOnly
        ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme
        : null;
}