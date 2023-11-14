namespace Memorabilia.Blazor.Controls.Dialogs;

public class ScrollableDialog : Dialog
{
    protected override void OnInitialized()
    {
        DialogStyle = Style.ScrollableDialog;
    }
}
