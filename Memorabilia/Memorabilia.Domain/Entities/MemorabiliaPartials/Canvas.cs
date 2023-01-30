namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetCanvas(int brandId,
                          bool matted,
                          int orientationId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          bool stretched,
                          int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, matted, stretched);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
