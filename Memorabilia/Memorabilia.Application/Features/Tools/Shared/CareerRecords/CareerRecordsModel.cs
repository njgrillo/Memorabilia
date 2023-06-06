using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordsModel
{
    public CareerRecordsModel() { }

    public CareerRecordsModel(IEnumerable<CareerRecord> careerRecords, Constant.Sport sport)
    {
        CareerRecords = careerRecords.Select(record => new CareerRecordModel(record, sport))
                                     .OrderBy(record => record.CareerRecordTypeName);
    }        

    public IEnumerable<CareerRecordModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordModel>();
}
