namespace IdentityServerHost.Pages.Login;

public class LoginOptions
{
    public const bool AllowLocalLogin = true;
    public const bool AllowRememberLogin = true;
    public const string InvalidCredentialsErrorMessage = "Invalid username or password";

    public static readonly TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
}