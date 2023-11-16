namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetHelmet(int brandId,
                          DateTime? gameDate,
                          int? gameStyleTypeId,
                          int? helmetFinishId,
                          int? helmetQualityTypeId,
                          int? helmetTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          bool throwback,
                          params int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportIds);
        SetHelmet(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
        SetGame(gameStyleTypeId, personIds.HasAny() ? personIds.First() : null, gameDate);
        SetTeams(teamIds);
        SetPeople(personIds);
    }

    private void SetHelmet(int? helmetFinishId, int? helmetQualityTypeId, int? helmetTypeId, bool throwback)
    {
        if (Helmet == null)
        {
            Helmet = new MemorabiliaHelmet(Id, helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
            return;
        }

        Helmet.Set(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
    }
}
