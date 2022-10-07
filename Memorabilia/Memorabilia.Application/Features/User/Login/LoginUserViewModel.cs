namespace Memorabilia.Application.Features.User.Login;

public class LoginUserViewModel : ViewModel
{
    public LoginUserViewModel() { }

    public override string PageTitle => "Graphinallday";

    [Required]
    [StringLength(50, ErrorMessage = "Password is too long.")]
    [MinLength(8, ErrorMessage = "Password is too short.")]
    public string Password { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "User Name is too long.")]
    [MinLength(1, ErrorMessage = "User Name is too short.")]
    public string Username { get; set; }
}
