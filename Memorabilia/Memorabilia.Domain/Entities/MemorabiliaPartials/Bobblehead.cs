namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBobblehead(int brandId,
                              bool hasBox,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int? sportId,
                              int? teamId,
                              int? year)
    {
        SetBrand(brandId);
        SetBobblehead(year, hasBox);
        SetLevelType(levelTypeId);
        SetSize(sizeId);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = [];
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }

    private void SetBobblehead(int? year, bool hasBox)
    {
        if (Bobblehead == null)
        {
            Bobblehead = new MemorabiliaBobblehead(Id, year, hasBox);
            return;
        }

        Bobblehead.Set(year, hasBox);
    }
}
