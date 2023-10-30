namespace Memorabilia.Blazor.Controls.Grids.Buttons;

public partial class DeleteGridButton
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public Color Color { get; set; }
        = Color.Secondary;

    [Parameter]
    public string ConfirmMessage { get; set; }

    [Parameter]
    public EventCallback OnDelete { get; set; }

    [Parameter]
    public bool ShowConfirm { get; set; }

    [Parameter]
    public MudBlazor.Size Size { get; set; }
        = MudBlazor.Size.Medium;

    [Parameter]
    public string StartIcon { get; set; }
        = Icons.Material.Outlined.DeleteOutline;

    [Parameter]
    public string TooltipText { get; set; }
        = "Delete";

    [Parameter]
    public bool Visible { get; set; }
        = true;

    public async Task ButtonClicked()
    {
        if (!ShowConfirm)
        {
            await OnDelete.InvokeAsync();
            return;
        }

        await ShowConfirmDelete();
    }

    private async Task ShowConfirmDelete()
    {
        var dialog = DialogService.Show<DeleteDialog>(ConfirmMessage);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await OnDelete.InvokeAsync();
    }
}
