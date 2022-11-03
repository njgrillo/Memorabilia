using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Accomplishments;

public class AccomplishmentViewModel
{
    private readonly PersonAccomplishment _personAccomplishment;

    public AccomplishmentViewModel(PersonAccomplishment personAccomplishment)
    {
        _personAccomplishment = personAccomplishment;
    }

    public int AccomplishmentTypeId => _personAccomplishment.AccomplishmentTypeId;

    public string AccomplishmentTypeName => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId)?.Name;

    public string Date => _personAccomplishment.Date?.ToString("MM/dd/yyyy");

    public int PersonId => _personAccomplishment.PersonId;

    public string PersonImagePath => _personAccomplishment.Person.ImagePath;

    public string PersonName => _personAccomplishment.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string Year => _personAccomplishment?.Year.ToString();
}
