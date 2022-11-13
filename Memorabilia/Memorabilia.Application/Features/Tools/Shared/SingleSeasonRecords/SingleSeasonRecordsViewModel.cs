using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public class SingleSeasonRecordsViewModel
{
    public SingleSeasonRecordsViewModel() { }

    public SingleSeasonRecordsViewModel(IEnumerable<SingleSeasonRecord> singleSeasonRecords, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        SingleSeasonRecords = singleSeasonRecords.Select(record => new SingleSeasonRecordViewModel(record, sportLeagueLevel))
                                                 .OrderBy(record => record.SingleSeasonRecordTypeName);
    }

    public IEnumerable<SingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordViewModel>();
}
