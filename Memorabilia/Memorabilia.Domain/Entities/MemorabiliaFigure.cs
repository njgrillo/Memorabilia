namespace Memorabilia.Domain.Entities;

public class MemorabiliaFigure : Entity
{
    public MemorabiliaFigure() { }

    public MemorabiliaFigure(int memorabiliaId, int? figureSpecialtyTypeId, int? figureTypeId, int? year)
    {
        MemorabiliaId = memorabiliaId;
        FigureSpecialtyTypeId = figureSpecialtyTypeId;
        FigureTypeId = figureTypeId;
        Year = year;
    }

    public int? FigureSpecialtyTypeId { get; private set; }

    public int? FigureTypeId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int? Year { get; private set; }

    public void Set(int? figureSpecialtyTypeId, int? figureTypeId, int? year)
    {
        FigureSpecialtyTypeId = figureSpecialtyTypeId;
        FigureTypeId = figureTypeId;
        Year = year;
    }
}
