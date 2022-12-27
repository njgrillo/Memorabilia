namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetMagazine(int brandId,
                            DateTime? date,
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
        SetMagazine(orientationId, date, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetMagazine(int orientationId, DateTime? date, bool framed, bool matted)
    {
        if (Magazine == null)
        {
            Magazine = new MemorabiliaMagazine(Id, orientationId, date, framed, matted);
            return;
        }

        Magazine.Set(orientationId, date, framed, matted);
    }
}
