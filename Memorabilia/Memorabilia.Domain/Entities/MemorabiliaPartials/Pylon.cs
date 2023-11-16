namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPylon(DateTime? gameDate,
                     int? gameStyleTypeId,
                     int levelTypeId,
                     int sizeId,
                     int sportId,
                     int? teamId)
    {
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId: gameStyleTypeId, gameDate: gameDate);
        SetSports(sportId);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }
}
