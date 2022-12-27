namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetCerealBox(int brandId,
                             int levelTypeId,
                             int[] personIds,
                             int[] sportIds,
                             int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
