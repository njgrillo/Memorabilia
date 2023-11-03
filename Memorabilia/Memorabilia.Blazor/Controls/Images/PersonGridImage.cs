namespace Memorabilia.Blazor.Controls.Images;

public class PersonGridImage : GridImage
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public int PersonId { get; set; }

    protected override async Task OnImageClick()
    {
        await ShowPersonProfileDialog();
    }

    protected async Task ShowPersonProfileDialog()
    {
        if (PersonId == 0)
            return;

        var parameters = new DialogParameters
        {
            ["PersonId"] = PersonId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }
}
