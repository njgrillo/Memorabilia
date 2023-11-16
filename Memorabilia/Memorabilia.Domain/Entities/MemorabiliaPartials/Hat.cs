namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetHat(int brandId,
                       DateTime? gameDate,
                       int? gameStyleTypeId,
                       int levelTypeId,
                       int[] personIds,
                       int sizeId,
                       int? sportId,
                       int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personIds.Length != 0 ? personIds.First() : null, gameDate);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = [];
        else
            SetSports(sportId.Value);
    }
}
