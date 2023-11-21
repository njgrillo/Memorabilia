namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class PersonProfileModel(Entity.Person person)
{
    public string BirthDate
        => $"Born {person.BirthDate?.ToString("MM/dd/yyyy")}";    

    public string DeathDate
        => $"Died {person.DeathDate?.ToString("MM/dd/yyyy")}";

    public bool HasBirthDate
        => person.BirthDate.HasValue;

    public bool HasDeathDate
        => person.DeathDate.HasValue;

    public string LifespanHeader
        => person.DeathDate.HasValue
            ? $"Born {person.BirthDate?.ToString("MM/dd/yyyy")} | Died {person.DeathDate?.ToString("MM/dd/yyyy")}"
            : $"Born {person.BirthDate?.ToString("MM/dd/yyyy")}";

    public string NameHeader 
        => person.ProfileName;

    public string Nicknames
        => person.Nicknames.Count != 0
            ? string.Join(" | ", person.Nicknames.Select(personNickname => personNickname.Nickname))
            : string.Empty;

    public string PersonImageFileName 
        => person.ImageFileName;
}
