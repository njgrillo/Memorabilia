namespace Memorabilia.Blazor.Pages.Person;

public partial class CondensedPersonSelector
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public PersonModel SelectedPerson { get; set; }
        = new();

    [Parameter]
    public EventCallback<PersonModel> SelectedPersonChanged { get; set; }

    [Parameter]
    public string Style { get; set; }

    public PersonModel Model
    {
        get => SelectedPerson;
        set
        {
            SelectedPerson = value;
            SelectedPersonChanged.InvokeAsync(value);
        }
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender)
            return;

        StateHasChanged();
    }

    private async Task ShowPersonProfile()
    {
        if ((SelectedPerson?.Id ?? 0) == 0)
            return;

        var parameters = new DialogParameters
        {
            ["PersonId"] = SelectedPerson.Id
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
