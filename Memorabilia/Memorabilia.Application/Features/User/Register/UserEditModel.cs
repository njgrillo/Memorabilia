namespace Memorabilia.Application.Features.User.Register;

public class UserEditModel : EditModel
{
    public UserEditModel() { }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "First Name is too long.")]
    [MinLength(1, ErrorMessage = "First Name is too short.")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Last Name is too long.")]
    [MinLength(1, ErrorMessage = "Last Name is too short.")]
    public string LastName { get; set; }

    public override string PageTitle 
        => "Register";
}
