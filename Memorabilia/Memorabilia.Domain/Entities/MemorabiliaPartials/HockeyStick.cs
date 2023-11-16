namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetHockeyStick(int brandId,
                               DateTime? gameDate,
                               int? gameStyleTypeId,
                               int levelTypeId,
                               int? personId,
                               int sizeId,
                               int sportId,
                               int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSports(sportId);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }
}
