﻿namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ViewThroughTheMail
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected List<ThroughTheMailModel> Items { get; set; }
        = new();

    protected List<ThroughTheMailModel> ReceivedItems { get; set; }
        = new();

    protected List<ThroughTheMailModel> SentItems { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.ThroughTheMail[] throughTheMails = await QueryRouter.Send(new GetThroughTheMails());

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
