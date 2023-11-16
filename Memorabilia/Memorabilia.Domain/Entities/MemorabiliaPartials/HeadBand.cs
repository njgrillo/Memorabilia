namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetHeadBand(int brandId,
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int? personId,
                            int? sportId,
                            int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = [];
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }
}
