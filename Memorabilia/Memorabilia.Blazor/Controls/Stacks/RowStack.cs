namespace Memorabilia.Blazor.Controls.Stacks;

public class RowStack : Stack
{
    protected override void OnInitialized()
    {
        IsRow = true;
    }
}
