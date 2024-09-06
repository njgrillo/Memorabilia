namespace Memorabilia.Application.Features.DisplayCase;

public class DisplayCaseDimensionModel
{
    private readonly Entity.DisplayCaseDimension _displayCaseDimension;

    public DisplayCaseDimensionModel() { }

    public DisplayCaseDimensionModel(Entity.DisplayCaseDimension displayCaseDimension)
    {
        _displayCaseDimension = displayCaseDimension;
    }

    public int ColumnIndex 
        => _displayCaseDimension.ColumnIndex;

    public int DisplayCaseId 
        => _displayCaseDimension.DisplayCaseId;

    public int RowCount
        => _displayCaseDimension.RowCount;
}
