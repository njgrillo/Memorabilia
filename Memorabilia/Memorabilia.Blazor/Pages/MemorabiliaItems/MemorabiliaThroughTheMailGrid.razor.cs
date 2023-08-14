namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaThroughTheMailGrid
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int[] ThroughTheMailIds { get; set; }
        = Array.Empty<int>();

    protected ThroughTheMailModel[] Items { get; set; }
        = Array.Empty<ThroughTheMailModel>();

    protected override async Task OnInitializedAsync()
    {
        if (!ThroughTheMailIds.Any())
            return;

        Entity.ThroughTheMail[] throughTheMails = await QueryRouter.Send(new GetThroughTheMails(ThroughTheMailIds));

        Items = throughTheMails.Select(item => new ThroughTheMailModel(item))
                               .ToArray();
    }

    private async Task ShowPersonProfile(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
    }
}
