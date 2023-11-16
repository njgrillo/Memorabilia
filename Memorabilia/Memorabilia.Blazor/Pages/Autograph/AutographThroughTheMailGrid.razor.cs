namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographThroughTheMailGrid
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public int ThroughTheMailId { get; set; }

    protected ThroughTheMailModel[] Items { get; set; }
        = [];

    protected ThroughTheMailModel ThroughTheMail { get; set; }
        = new();

    protected ThroughTheMailMemorabiliaModel ThroughTheMailMemorabilia { get; set; }
        = new();

    protected override async Task OnParametersSetAsync()
    {
        if (ThroughTheMailId == 0)
            return;

        Entity.ThroughTheMail throughTheMail 
            = await Mediator.Send(new GetThroughTheMail(ThroughTheMailId));

        ThroughTheMail = new(throughTheMail);
        ThroughTheMailMemorabilia = new(ThroughTheMail.Memorabilia.FirstOrDefault(item => item.AutographId == AutographId));

        var items = new List<ThroughTheMailModel> { ThroughTheMail };

        Items = items.ToArray();
    }
}
