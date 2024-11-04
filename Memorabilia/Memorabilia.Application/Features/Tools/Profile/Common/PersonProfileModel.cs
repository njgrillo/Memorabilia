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

    public bool HasLifespan
        => HasBirthDate || HasDeathDate; 

    public string LegalName
        => person.LegalName;

    public string LifespanHeader
        => $"Born: {(HasBirthDate ? person.BirthDate?.ToString("MM/dd/yyyy") : "Unknown")} {(HasDeathDate ? $" | Died: {person.DeathDate?.ToString("MM/dd/yyyy")}" : UnknownDeathDateText)}";

    public string NameHeader 
        => person.ProfileName;

    public string Nicknames
    {
        get
        {
            if (person.Nicknames.Count == 0)
                return string.Empty;

            string nicknames = string.Join(" | ", person.Nicknames.Select(personNickname => personNickname.Nickname));

            return nicknames.Length > 50
                ? $"{nicknames[..47]}..." 
                : nicknames;
        }
    }

    public string PersonImageFileName 
        => person.ImageFileName;

    public string UnknownDeathDateText
        => HasBirthDate
            ? person.BirthDate.Value.Year < (DateTime.Now.Year - 115) ? " | Died: Unknown" : string.Empty
            : string.Empty;
}
