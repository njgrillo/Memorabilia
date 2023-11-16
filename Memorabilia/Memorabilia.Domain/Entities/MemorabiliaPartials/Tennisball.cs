namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetTennisball(int brandId,
                              DateTime? gameDate,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int sportId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);
    }
}
