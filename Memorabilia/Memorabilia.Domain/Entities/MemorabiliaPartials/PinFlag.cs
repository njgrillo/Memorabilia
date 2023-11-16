namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPinFlag(DateTime? gameDate,
                           int? gameStyleTypeId,
                           int? personId,
                           int sportId)
    {
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSports(sportId);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);
    }
}
