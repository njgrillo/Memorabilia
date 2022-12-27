namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetFigure(int brandId,
                          int? figureSpecialtyTypeId,
                          int? figureTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          int[] teamIds,
                          int? year)
    {
        SetBrand(brandId);
        SetFigureType(figureSpecialtyTypeId, figureTypeId, year);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetFigureType(int? figureSpecialtyTypeId, int? figureTypeId, int? year)
    {
        if (figureSpecialtyTypeId.HasValue || figureTypeId.HasValue || year.HasValue)
        {
            if (Figure == null)
            {
                Figure = new MemorabiliaFigure(Id, figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
                return;
            }

            Figure.Set(figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
        }
        else
        {
            if (Figure?.Id > 0)
                Figure = null;
        }
    }
}
