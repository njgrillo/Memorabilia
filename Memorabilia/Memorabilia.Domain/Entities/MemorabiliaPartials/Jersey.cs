namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetJersey(int brandId,
                          DateTime? gameDate,
                          int? gameStyleTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int qualityTypeId,
                          int sizeId,
                          int? sportId,
                          int styleTypeId,
                          int[] teamIds,
                          int typeId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetJersey(qualityTypeId, styleTypeId, typeId);
        SetGame(gameStyleTypeId, personIds.HasAny() ? personIds.First() : null, gameDate);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = [];
        else
            SetSports(sportId.Value);
    }

    private void SetJersey(int qualityTypeId, int styleTypeId, int typeId)
    {
        if (Jersey == null)
        {
            Jersey = new MemorabiliaJersey(Id, qualityTypeId, styleTypeId, typeId);
            return;
        }

        Jersey.Set(qualityTypeId, styleTypeId, typeId);
    }
}
