using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class PersonProfileViewModel
{
    private readonly Person _person;

    public PersonProfileViewModel(Person person)
    {
        _person = person;
    }

    public string LifespanHeader
        => _person.DeathDate.HasValue
        ? $"Born {_person.BirthDate?.ToString("MM/dd/yyyy")} | Died {_person.DeathDate?.ToString("MM/dd/yyyy")}"
        : $"Born {_person.BirthDate?.ToString("MM/dd/yyyy")}";

    public string NameHeader => _person.ProfileName;

    public string Nicknames
        => _person.Nicknames.Any()
        ? string.Join(" | ", _person.Nicknames.Select(personNickname => personNickname.Nickname))
        : string.Empty;

    public string PersonImageFileName => _person.ImageFileName;
}
