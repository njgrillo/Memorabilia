namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBasketball(int? basketballTypeId,
                              int brandId,
                              int commissionerId,
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
        SetBasketballType(basketballTypeId.Value);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }

    private void SetBasketballType(int? basketballTypeId)
    {
        if (basketballTypeId.HasValue)
        {
            if (Basketball == null)
            {
                Basketball = new MemorabiliaBasketball(Id, basketballTypeId.Value);
                return;
            }

            Basketball.Set(basketballTypeId.Value);
        }
        else
        {
            if (Basketball?.Id > 0)
                Basketball = null;
        }
    }
}
