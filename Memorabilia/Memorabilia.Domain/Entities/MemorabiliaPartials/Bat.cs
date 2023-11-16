namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBat(int? batTypeId,
                       int brandId,
                       int? colorId,
                       DateTime? gameDate,
                       int? gameStyleTypeId,
                       int? length,
                       int? personId,
                       int sizeId,
                       int sportId,
                       int? teamId)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetSports(sportId);
        SetBatType(batTypeId, colorId, length);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = [];
        else
            SetTeams(teamId.Value);
    }

    private void SetBatType(int? batTypeId, int? colorId, int? length)
    {
        if (batTypeId.HasValue || colorId.HasValue || length.HasValue)
        {
            if (Bat == null)
            {
                Bat = new MemorabiliaBat(Id, batTypeId, colorId, length);
                return;
            }

            Bat.Set(batTypeId, colorId, length);
        }
        else
        {
            if (Bat?.Id > 0)
                Bat = null;
        }
    }
}
