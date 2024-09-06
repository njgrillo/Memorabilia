namespace Memorabilia.Domain.Entities;

public class DisplayCaseDimension : Entity
{
    public DisplayCaseDimension() { }

    public DisplayCaseDimension(int columnIndex, int displayCaseId, int rowCount)
    {
        ColumnIndex = columnIndex;
        DisplayCaseId = displayCaseId;
        RowCount = rowCount;
    }

    public int ColumnIndex { get; private set; }

    public int DisplayCaseId { get; private set; }

    public int RowCount { get; private set; }

    public void Set(int rowCount)
    {
        RowCount = rowCount;
    }
}
