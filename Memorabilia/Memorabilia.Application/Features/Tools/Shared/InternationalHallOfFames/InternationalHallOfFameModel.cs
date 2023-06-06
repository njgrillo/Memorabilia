using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public class InternationalHallOfFameModel : PersonSportToolModel
{
    private readonly InternationalHallOfFame _internationalHallOfFame;

    public InternationalHallOfFameModel(InternationalHallOfFame internationalHallOfFame, Constant.Sport sport)
    {
        _internationalHallOfFame = internationalHallOfFame;
        Sport = sport;
    }    

    public string InductionYear => _internationalHallOfFame.InductionYear.ToString();

    public string InternationalHallOfFameTypeName => _internationalHallOfFame.InternationalHallOfFameType?.Name;

    public override int PersonId => _internationalHallOfFame.PersonId;

    public override string PersonImageFileName => _internationalHallOfFame.Person.ImageFileName;

    public override string PersonName => _internationalHallOfFame.Person.DisplayName;
}
