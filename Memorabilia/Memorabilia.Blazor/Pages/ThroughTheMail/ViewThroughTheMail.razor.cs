namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ViewThroughTheMail
{
    [Inject]
    public IMediator Mediator { get; set; }

    protected List<ThroughTheMailModel> Items { get; set; }
        = [];

    protected List<ThroughTheMailModel> ReceivedItems { get; set; }
        = [];

    protected List<ThroughTheMailModel> SentItems { get; set; }
        = [];

    protected override async Task OnInitializedAsync()
    {
        Entity.ThroughTheMail[] throughTheMails 
            = await Mediator.Send(new GetThroughTheMails());

        Items = throughTheMails.Select(throughTheMail => new ThroughTheMailModel(throughTheMail))
                               .ToList();

        ReceivedItems = Items.Where(item => item.ReceivedDate.HasValue || item.Memorabilia.Any(item => item.AutographId.HasValue))
                             .OrderByDescending(item => item.ReceivedDate)
                             .ToList();

        SentItems = Items.Where(item => !item.ReceivedDate.HasValue && item.Memorabilia.All(item => !item.AutographId.HasValue))
                         .OrderByDescending(item => item.SentDate)
                         .ToList();
    }    
}
