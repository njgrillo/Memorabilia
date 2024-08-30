namespace Memorabilia.Application.Features.Memorabilia.History.Memorabilia;

public class MemorabiliaItemHistoriesModel : Model
{
    public MemorabiliaItemHistoriesModel() { }

    public MemorabiliaItemHistoriesModel(
        IEnumerable<Entity.Memorabilia> memorabiliaHistories,
        PageInfoResult pageInfo = null)
    {
        HistoryItems 
            = memorabiliaHistories.Select(memorabiliaHistoryItem => new MemorabiliaItemHistoryModel(memorabiliaHistoryItem))
                                  .ToList();

        PageInfo = pageInfo;
    }

    public List<MemorabiliaItemHistoryModel> HistoryItems { get; set; }
        = [];
}
