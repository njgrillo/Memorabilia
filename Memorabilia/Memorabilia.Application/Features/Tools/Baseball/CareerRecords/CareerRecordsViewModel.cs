using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.CareerRecords;

public class CareerRecordsViewModel
{
    public CareerRecordsViewModel() { }

    public CareerRecordsViewModel(IEnumerable<CareerRecord> careerRecords)
    {
        CareerRecords = careerRecords.Select(record => new CareerRecordViewModel(record))
                                     .OrderBy(record => record.CareerRecordTypeName);
    }        

    public IEnumerable<CareerRecordViewModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordViewModel>();
}
