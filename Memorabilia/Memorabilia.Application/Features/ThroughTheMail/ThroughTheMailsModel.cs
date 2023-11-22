namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailsModel : Model
{
    public ThroughTheMailsModel() { }

    public ThroughTheMailsModel(Entity.ThroughTheMail[] items)
    {
        Items
            = items.Select(throughTheMail => new ThroughTheMailModel(throughTheMail))
                   .ToList();
    }

    public ThroughTheMailsModel(Entity.ThroughTheMail[] items,
                                PageInfoResult pageInfo)
    {
        Items
            = items.Select(throughTheMail => new ThroughTheMailModel(throughTheMail))
                   .ToList();

        PageInfo = pageInfo;
    }

    public List<ThroughTheMailModel> Items { get; set; }
        = [];
}
