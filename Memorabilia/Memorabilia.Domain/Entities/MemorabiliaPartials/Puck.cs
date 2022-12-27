namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPuck(int brandId,
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
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetPeople(teamId.Value);
    }
}
