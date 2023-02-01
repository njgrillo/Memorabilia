namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetCerealBox(int brandId,
                             int? cerealTypeId,
                             int levelTypeId,
                             int[] personIds,
                             int[] sportIds,
                             int[] teamIds)
    {
        SetBrand(brandId);
        SetCerealType(cerealTypeId);
        SetLevelType(levelTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetCerealType(int? cerealTypeId)
    {
        if (cerealTypeId.HasValue)
        {
            if (Cereal == null)
            {
                Cereal = new MemorabiliaCereal(Id, cerealTypeId.Value);
                return;
            }

            Cereal.Set(cerealTypeId.Value);
        }
        else
        {
            if (Cereal?.Id > 0)
                Cereal = null;
        }
    }
}
