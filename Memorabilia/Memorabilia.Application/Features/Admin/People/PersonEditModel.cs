namespace Memorabilia.Application.Features.Admin.People;

public class PersonEditModel 
    : EditModel, IWithName, IWithValue<int>
{
    public PersonEditModel() { }

    public PersonEditModel(PersonModel model)
    {
        BirthDate = model.BirthDate;
        DeathDate = model.DeathDate;
        DisplayName = model.DisplayName;
        FirstName = model.FirstName;            
        Id = model.Id;
        LastName = model.LastName;
        LegalName = model.LegalName;
        MiddleName = model.MiddleName;
        Nickname = model.Nickname;
        Nicknames = model.Nicknames.ToEditModelList();
        PersonImageFileName = model.ImageFileName;
        ProfileName = model.ProfileName;
        Suffix = model.Suffix;          
        Teams = model.Teams.ToEditModelList();
    }

    public override string BackNavigationPath 
        => Constant.AdminDomainItem.People.Page;

    public DateTime? BirthDate { get; set; }

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Occupations.Item}/{Constant.EditModeType.Update.Name}/{Id}";

    public DateTime? DeathDate { get; set; }

    public string DisplayName { get; set; }

    public override string ExitNavigationPath 
        => "Admin/EditDomainItems";

    public string FirstName { get; set; }

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => Constant.AdminDomainItem.People.Item;

    public string LastName { get; set; }

    public string LegalName { get; set; }

    public string MenuItemPath
        => "People";

    public string MiddleName { get; set; }

    public override string Name 
        => ProfileName;

    public string Nickname { get; set; }

    public List<PersonNicknameEditModel> Nicknames { get; set; } 
        = new();

    public string PersonImageFileName { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Person;

    public string ProfileName { get; set; }

    public override string RoutePrefix 
        => Constant.AdminDomainItem.People.Page;

    public string Suffix { get; set; }

    public List<PersonTeamEditModel> Teams { get; set; } 
        = new();

    public override string ToString()
        => Name;

    int IWithValue<int>.Value 
        => Id;
}
