namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPoster(int brandId,
                          bool framed,
                          bool matted,
                          int orientationId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
