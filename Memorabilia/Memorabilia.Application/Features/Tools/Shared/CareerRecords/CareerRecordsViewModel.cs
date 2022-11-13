using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.CareerRecords;

public class CareerRecordsViewModel
{
    public CareerRecordsViewModel() { }

    public CareerRecordsViewModel(IEnumerable<CareerRecord> careerRecords, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        CareerRecords = careerRecords.Select(record => new CareerRecordViewModel(record, sportLeagueLevel))
                                     .OrderBy(record => record.CareerRecordTypeName);
    }        

    public IEnumerable<CareerRecordViewModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordViewModel>();
}
