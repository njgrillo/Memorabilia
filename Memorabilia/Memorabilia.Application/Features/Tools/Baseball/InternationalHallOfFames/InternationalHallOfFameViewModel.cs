using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.InternationalHallOfFames;

public class InternationalHallOfFameViewModel
{
    private readonly InternationalHallOfFame _internationalHallOfFame;

    public InternationalHallOfFameViewModel(InternationalHallOfFame internationalHallOfFame)
    {
        _internationalHallOfFame = internationalHallOfFame;
    }    

    public string InductionYear => _internationalHallOfFame.InductionYear.ToString();

    public string InternationalHallOfFameTypeName => _internationalHallOfFame.InternationalHallOfFameType?.Name;

    public int PersonId => _internationalHallOfFame.PersonId;

    public string PersonImagePath => _internationalHallOfFame.Person.ImagePath;

    public string PersonName => _internationalHallOfFame.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";
}
