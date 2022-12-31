using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordsViewModel
{
    public CareerRecordsViewModel() { }

    public CareerRecordsViewModel(IEnumerable<CareerRecord> careerRecords, Domain.Constants.Sport sport)
    {
        CareerRecords = careerRecords.Select(record => new CareerRecordViewModel(record, sport))
                                     .OrderBy(record => record.CareerRecordTypeName);
    }        

    public IEnumerable<CareerRecordViewModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordViewModel>();
}
