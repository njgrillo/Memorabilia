namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class Dialog
{
    [Parameter]
    public RenderFragment ActionsContent { get; set; }    

    [Parameter]
    public RenderFragment DialogContent { get; set; }

    [Parameter]
    public string DialogStyle { get; set; }
        = Style.Dialog;

    [Parameter]
    public bool DisplayCancelButton { get; set; }

    [Parameter]
    public bool DisplayCloseButton { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    public async Task Cancel()
    {
        await OnCancel.InvokeAsync();
    }

    public async Task Close()
    {
        await OnClose.InvokeAsync();
    }
}
