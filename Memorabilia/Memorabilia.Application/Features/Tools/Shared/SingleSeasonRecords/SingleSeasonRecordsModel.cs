using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.SingleSeasonRecords;

public class SingleSeasonRecordsModel
{
    public SingleSeasonRecordsModel() { }

    public SingleSeasonRecordsModel(IEnumerable<SingleSeasonRecord> singleSeasonRecords, Constant.Sport sport)
    {
        SingleSeasonRecords = singleSeasonRecords.Select(record => new SingleSeasonRecordModel(record, sport))
                                                 .OrderBy(record => record.SingleSeasonRecordTypeName);
    }

    public IEnumerable<SingleSeasonRecordModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordModel>();
}
