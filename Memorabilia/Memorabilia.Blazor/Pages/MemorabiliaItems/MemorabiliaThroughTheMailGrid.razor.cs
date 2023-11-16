namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaThroughTheMailGrid
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int[] ThroughTheMailIds { get; set; }
        = [];

    protected ThroughTheMailModel[] Items { get; set; }
        = [];

    protected override async Task OnInitializedAsync()
    {
        if (ThroughTheMailIds.IsNullOrEmpty())
            return;

        Entity.ThroughTheMail[] throughTheMails 
            = await Mediator.Send(new GetThroughTheMails(ThroughTheMailIds));

        Items = throughTheMails.Select(item => new ThroughTheMailModel(item))
                               .ToArray();
    }
}
