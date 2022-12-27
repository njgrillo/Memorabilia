namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetCard(int brandId,
                       bool custom,
                       int levelTypeId,
                       bool licensed,
                       int orientationId,
                       int[] personIds,
                       int sizeId,
                       int[] sportIds,
                       int[] teamIds,
                       int? year)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetCard(orientationId, custom, licensed, year);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetCard(int orientationId, bool custom, bool licensed, int? year)
    {
        if (Card == null)
        {
            Card = new MemorabiliaCard(Id, orientationId, custom, licensed, year);
            return;
        }

        Card.Set(orientationId, custom, licensed, year);
    }
}
