namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPlayingCard(int? personId, int sizeId, int? sportId, int? teamId)
    {
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
