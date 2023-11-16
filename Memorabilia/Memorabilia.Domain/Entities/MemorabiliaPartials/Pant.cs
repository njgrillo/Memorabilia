namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPant(int brandId,
                        DateTime? gameDate,
                        int? gameStyleTypeId,
                        int levelTypeId,
                        int? personId,
                        int sizeId,
                        int? sportId,
                        int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
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
