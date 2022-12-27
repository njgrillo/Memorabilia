namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetHeadBand(int brandId,
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
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSize(sizeId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }
}
