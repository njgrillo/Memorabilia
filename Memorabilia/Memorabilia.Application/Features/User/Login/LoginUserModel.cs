namespace Memorabilia.Application.Features.User.Login;

public class LoginUserModel : Model
{
    public LoginUserModel() { }

    public override string PageTitle 
        => "Graphinallday";

    public string Password { get; set; }

    public string Username { get; set; }
}
