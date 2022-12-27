namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetGlove(int brandId,
                         DateTime? gameDate,
                         int? gameStyleTypeId,
                         int? gloveTypeId,
                         int levelTypeId,
                         int[] personIds,
                         int sizeId,
                         int? sportId,
                         int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personIds.FirstOrDefault(), gameDate);
        SetGloveType(gloveTypeId);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    private void SetGloveType(int? gloveTypeId)
    {
        if (gloveTypeId.HasValue)
        {
            if (Glove == null)
            {
                Glove = new MemorabiliaGlove(Id, gloveTypeId.Value);
                return;
            }

            Glove.Set(gloveTypeId.Value);
        }
        else
        {
            if (Glove?.Id > 0)
                Glove = null;
        }
    }
}
