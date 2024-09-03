namespace Memorabilia.Application.Features.Autograph.History.Autograph;

public class AutographHistoriesModel : Model
{
    public AutographHistoriesModel() { }

    public AutographHistoriesModel(
        IEnumerable<Entity.Autograph> autographHistories,
        PageInfoResult pageInfo = null)
    {
        HistoryItems
            = autographHistories.Select(autographHistory => new AutographHistoryModel(autographHistory))
                                .ToList();

        PageInfo = pageInfo;
    }

    public List<AutographHistoryModel> HistoryItems { get; set; }
        = [];
}
