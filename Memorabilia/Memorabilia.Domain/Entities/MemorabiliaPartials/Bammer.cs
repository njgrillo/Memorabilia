namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBammer(int? bammerTypeId,
                          int brandId,
                          bool inPackage,
                          int levelTypeId,
                          int[] personIds,
                          int? sportId,
                          int[] teamIds,
                          int? year)
    {
        SetBrand(brandId);
        SetBammerType(bammerTypeId, inPackage, year);
        SetLevelType(levelTypeId);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    private void SetBammerType(int? bammerTypeId, bool inPackage, int? year)
    {
        if (bammerTypeId.HasValue)
        {
            if (Brand.BrandId != Constants.Brand.Salvino.Id)
                return;

            if (Bammer == null)
            {
                Bammer = new MemorabiliaBammer(Id, bammerTypeId.Value, inPackage, year);
                return;
            }

            Bammer.Set(bammerTypeId.Value, inPackage, year);
        }
        else
        {
            if (Bammer?.Id > 0)
                Bammer = null;
        }
    }
}
