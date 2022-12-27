namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetTicket(DateTime? gameDate,
                          int? gameStyleTypeId,
                          int levelTypeId,
                          int? personId,
                          int sizeId,
                          int? sportId,
                          int[] teamIds)
    {
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetTeams(teamIds);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }
}
