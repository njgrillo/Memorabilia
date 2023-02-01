namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetFootball(int brandId,
                            int commissionerId,
                            int? footballTypeId,
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
        SetSports(sportId);
        SetFootballType(footballTypeId);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    private void SetFootballType(int? footballTypeId)
    {
        if (footballTypeId.HasValue)
        {
            if (Football == null)
            {
                Football = new MemorabiliaFootball(Id, footballTypeId.Value);
                return;
            }

            Football.Set(footballTypeId.Value);
        }
        else
        {
            if (Football?.Id > 0)
                Football = null;
        }
    }
}
