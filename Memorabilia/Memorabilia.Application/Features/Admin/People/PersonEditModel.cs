namespace Memorabilia.Application.Features.Admin.People;

public class PersonEditModel 
    : EditModel, IWithName, IWithValue<int>
{
    public PersonEditModel() { }

    public PersonEditModel(PersonModel viewModel)
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
        Nicknames = viewModel.Nicknames.ToEditModelList();
        PersonImageFileName = viewModel.ImageFileName;
        ProfileName = viewModel.ProfileName;
        Suffix = viewModel.Suffix;          
        Teams = viewModel.Teams.ToEditModelList();
    }

    public override string BackNavigationPath 
        => Constant.AdminDomainItem.People.Page;

    public DateTime? BirthDate { get; set; }

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Occupations.Item}/{Constant.EditModeType.Update.Name}/{Id}";

    public DateTime? DeathDate { get; set; }

    [Required]
    [StringLength(225, ErrorMessage = "Display Name is too long.")]
    [MinLength(1, ErrorMessage = "First Name is too short.")]
    public string DisplayName { get; set; }

    public override string ExitNavigationPath 
        => "Admin/EditDomainItems";

    [Required]
    [StringLength(50, ErrorMessage = "First Name is too long.")]
    [MinLength(1, ErrorMessage = "First Name is too short.")]
    public string FirstName { get; set; }

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => Constant.AdminDomainItem.People.Item;

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

    public override string Name 
        => ProfileName;

    [StringLength(50, ErrorMessage = "Nickname is too long.")]
    public string Nickname { get; set; }

    public List<PersonNicknameEditModel> Nicknames { get; set; } 
        = new();

    public string PersonImageFileName { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Person;

    public string ProfileName { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.People.Page;

    [StringLength(25, ErrorMessage = "Suffix is too long.")]
    public string Suffix { get; set; }

    public List<PersonTeamEditModel> Teams { get; set; } 
        = new();

    public override string ToString()
        => Name;

    int IWithValue<int>.Value 
        => Id;
}
