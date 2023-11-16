namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPlayingCard(int? personId, int sizeId, int? sportId, int? teamId)
    {
        SetSize(sizeId);

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
