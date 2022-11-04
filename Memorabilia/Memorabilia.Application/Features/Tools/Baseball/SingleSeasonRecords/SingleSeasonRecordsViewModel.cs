using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.SingleSeasonRecords;

public class SingleSeasonRecordsViewModel
{
    public SingleSeasonRecordsViewModel() { }

    public SingleSeasonRecordsViewModel(IEnumerable<SingleSeasonRecord> singleSeasonRecords)
    {
        SingleSeasonRecords = singleSeasonRecords.Select(record => new SingleSeasonRecordViewModel(record))
                                                 .OrderBy(record => record.SingleSeasonRecordTypeName);
    }

    public IEnumerable<SingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordViewModel>();
}
