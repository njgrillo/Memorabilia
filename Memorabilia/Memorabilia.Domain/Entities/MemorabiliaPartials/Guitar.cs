namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetGuitar(int brandId, int[] personIds, int sizeId)
    {
        SetBrand(brandId);
        SetPeople(personIds);
        SetSize(sizeId);
    }
}
