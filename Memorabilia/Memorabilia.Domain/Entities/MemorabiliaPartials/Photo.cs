namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPhoto(int brandId,
                         bool framed,
                         bool matted,
                         int orientationId,
                         int[] personIds,
                         int? photoTypeId,
                         int sizeId,
                         int[] sportIds,
                         int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted, photoTypeId: photoTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
