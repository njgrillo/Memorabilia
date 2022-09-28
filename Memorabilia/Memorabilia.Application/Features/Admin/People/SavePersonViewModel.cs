using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonViewModel : SaveViewModel
    {
        public SavePersonViewModel() { }

        public SavePersonViewModel(PersonViewModel viewModel)
        {
            BirthDate = viewModel.BirthDate;
            DeathDate = viewModel.DeathDate;
            DisplayName = viewModel.DisplayName;
            FirstName = viewModel.FirstName;            
            Id = viewModel.Id;
            LastName = viewModel.LastName;
            LegalName = viewModel.LegalName;
            MiddleName = viewModel.MiddleName;
            Nickname = viewModel.Nickname;
            Nicknames = viewModel.Nicknames.Select(nickname => new SavePersonNicknameViewModel(new PersonNicknameViewModel(nickname))).ToList();
            PersonImagePath = viewModel.PersonImagePath;
            ProfileName = viewModel.ProfileName;
            Suffix = viewModel.Suffix;   
            Teams = viewModel.Teams.Select(team => new SavePersonTeamViewModel(new PersonTeamViewModel(team))).ToList();
        }

        public override string BackNavigationPath => "People";

        public DateTime? BirthDate { get; set; }

        public override string ContinueNavigationPath => $"People/Occupation/Edit/{Id}";

        public DateTime? DeathDate { get; set; }

        [Required]
        [StringLength(225, ErrorMessage = "Display Name is too long.")]
        [MinLength(1, ErrorMessage = "First Name is too short.")]
        public string DisplayName { get; set; }

        public override string ExitNavigationPath => "Admin/EditDomainItems";

        [Required]
        [StringLength(50, ErrorMessage = "First Name is too long.")]
        [MinLength(1, ErrorMessage = "First Name is too short.")]
        public string FirstName { get; set; }

        public string ImagePath => "images/athletes.jpg";

        public override string ItemTitle => "Person";

        [Required]
        [StringLength(50, ErrorMessage = "Last Name is too long.")]
        [MinLength(1, ErrorMessage = "Last Name is too short.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(225, ErrorMessage = "Legal Name is too long.")]
        [MinLength(1, ErrorMessage = "Legal Name is too short.")]
        public string LegalName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name is too long.")]
        public string MiddleName { get; set; }

        [StringLength(50, ErrorMessage = "Nickname is too long.")]
        public string Nickname { get; set; }

        public List<SavePersonNicknameViewModel> Nicknames { get; set; } = new();

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} Person";

        public string PersonImagePath { get; set; }

        public PersonStep PersonStep => PersonStep.Person;

        public string ProfileName { get; set; }

        public override string RoutePrefix => "People";

        [StringLength(25, ErrorMessage = "Suffix is too long.")]
        public string Suffix { get; set; }

        public List<SavePersonTeamViewModel> Teams { get; set; } = new();
    }
}
