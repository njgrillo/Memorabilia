namespace Memorabilia.Application.Features.User.Register
{
    public class SaveUserViewModel : SaveViewModel
    {
        public SaveUserViewModel() { }

        [Required]
        [StringLength(50, ErrorMessage = "Password is too long.")]
        [MinLength(8, ErrorMessage = "Password is too short.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email Address is too long.")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name is too long.")]
        [MinLength(1, ErrorMessage = "First Name is too short.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name is too long.")]
        [MinLength(1, ErrorMessage = "Last Name is too short.")]
        public string LastName { get; set; }

        public override string PageTitle => "Register";

        [Required]
        [StringLength(50, ErrorMessage = "Password is too long.")]
        [MinLength(8, ErrorMessage = "Password is too short.")]
        public string Password { get; set; }

        [StringLength(15, ErrorMessage = "Phone is too long.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "User Name is too long.")]
        [MinLength(1, ErrorMessage = "User Name is too short.")]
        public string Username { get; set; }
    }
}
