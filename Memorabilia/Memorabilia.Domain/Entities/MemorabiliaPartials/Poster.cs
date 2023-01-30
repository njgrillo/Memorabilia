namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPoster(int brandId,
                          bool matted,
                          int orientationId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
