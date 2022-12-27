namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetDrum(int brandId, int[] personIds)
    {
        SetBrand(brandId);
        SetPeople(personIds);
    }
}
