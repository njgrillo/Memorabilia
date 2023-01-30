namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetPhoto(int brandId,
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
        SetPicture(orientationId, matted, photoTypeId: photoTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }
}
