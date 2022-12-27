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
        SetGame(gameStyleTypeId, personIds.FirstOrDefault(), gameDate);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }
}
