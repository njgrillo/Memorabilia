namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBaseball(string anniversary,
                            int? baseballTypeId,
                            int brandId,
                            int commissionerId,
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int? leaguePresidentId,
                            int levelTypeId,
                            int? personId,
                            int sizeId,
                            int sportId,
                            int[] teamIds,
                            int? year)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetTeams(teamIds);
        SetBaseballType(baseballTypeId, leaguePresidentId, year, anniversary);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);
    }

    private void SetBaseballType(int? baseballTypeId, int? leaguePresidentId, int? year, string anniversary)
    {
        if (baseballTypeId.HasValue)
        {
            if (Brand.BrandId != Constant.Brand.Rawlings.Id)
                return;

            if (Baseball == null)
            {
                Baseball = new MemorabiliaBaseball(Id, baseballTypeId.Value, leaguePresidentId, year, anniversary);
                return;
            }

            Baseball.Set(baseballTypeId.Value, leaguePresidentId, year, anniversary);
        }
        else
        {
            if (Baseball?.Id > 0)
                Baseball = null;
        }
    }
}
