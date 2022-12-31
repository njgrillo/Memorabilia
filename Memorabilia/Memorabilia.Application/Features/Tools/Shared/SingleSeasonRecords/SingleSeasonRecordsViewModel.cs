using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public class SingleSeasonRecordsViewModel
{
    public SingleSeasonRecordsViewModel() { }

    public SingleSeasonRecordsViewModel(IEnumerable<SingleSeasonRecord> singleSeasonRecords, Domain.Constants.Sport sport)
    {
        SingleSeasonRecords = singleSeasonRecords.Select(record => new SingleSeasonRecordViewModel(record, sport))
                                                 .OrderBy(record => record.SingleSeasonRecordTypeName);
    }

    public IEnumerable<SingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordViewModel>();
}
