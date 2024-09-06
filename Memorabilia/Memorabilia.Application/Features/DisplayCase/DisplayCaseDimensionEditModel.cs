namespace Memorabilia.Application.Features.DisplayCase;

public class DisplayCaseDimensionEditModel : EditModel
{
    public DisplayCaseDimensionEditModel() { }

    public DisplayCaseDimensionEditModel(Entity.DisplayCaseDimension displayCaseDimension)
    {        
        ColumnIndex = displayCaseDimension.ColumnIndex;
        DisplayCaseId = displayCaseDimension.DisplayCaseId;
        RowCount = displayCaseDimension.RowCount;
    }

    public DisplayCaseDimensionEditModel(DisplayCaseDimensionModel displayCaseDimension)
    {
        ColumnIndex = displayCaseDimension.ColumnIndex;
        DisplayCaseId = displayCaseDimension.DisplayCaseId;
        RowCount = displayCaseDimension.RowCount;
    }

    public DisplayCaseDimensionEditModel(int columnIndex, int displayCaseId, int rowCount)
    {
        ColumnIndex = columnIndex;
        DisplayCaseId = displayCaseId;
        RowCount = rowCount;
    }

    public int ColumnIndex { get; set; }

    public int DisplayCaseId { get; set; }    

    public int RowCount { get; set; }
}
