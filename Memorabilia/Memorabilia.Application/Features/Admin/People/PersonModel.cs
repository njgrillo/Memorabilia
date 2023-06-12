namespace Memorabilia.Application.Features.Admin.People;

public class PersonModel 
    : Model, IWithName, IWithValue<int>
{
    private readonly Entity.Person _person;

    public PersonModel() 
    {
        _person = new();
    }

    public PersonModel(Entity.Person person)
    {
        _person = person;
    }

    public DateTime? BirthDate 
        => _person.BirthDate;

    public DateTime? DeathDate 
        => _person.DeathDate;

    public string DisplayName 
        => _person.DisplayName;

    public string FirstName 
        => _person.FirstName;    
    
    public string FormattedBirthDate 
        => _person.BirthDate?.ToString("MM-dd-yyyy") ?? string.Empty;

    public string FormattedDeathDate
        => _person.DeathDate?.ToString("MM-dd-yyyy") ?? string.Empty;

    public int Id 
        => _person.Id;

    public string ImageFileName 
        => _person.ImageFileName.IsNullOrEmpty()
        ? Constant.ImageFileName.ImageNotAvailable
        : _person.ImageFileName;

    public DateTime? LastModifiedDate 
        => _person.LastModifiedDate;

    public string LastName 
        => _person.LastName; 

    public string LegalName 
        => _person.LegalName;

    public string MiddleName 
        => _person.MiddleName;

    public override string Name 
        => DisplayName;

    public string Nickname 
        => _person.Nickname;

    public IEnumerable<Entity.PersonNickname> Nicknames 
        => _person.Nicknames;

    public IEnumerable<Entity.PersonOccupation> Occupations 
        => _person.Occupations;

    public string ProfileName 
        => _person.ProfileName;   

    public string Suffix 
        => _person.Suffix;

    public IEnumerable<Entity.PersonTeam> Teams 
        => _person.Teams;

    int IWithValue<int>.Value 
        => Id;
}
