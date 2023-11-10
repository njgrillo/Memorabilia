namespace Memorabilia.Blazor.Controls.Grids;

public class TableDataRightAligned : TableData
{
    protected override void OnInitialized()
    {
        Style = "text-align:right;";
    }
}
