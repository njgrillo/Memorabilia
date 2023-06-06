namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class CareerRecordsProfile : SportProfile
{
    private CareerRecordProfileModel[] CareerRecords = Array.Empty<CareerRecordProfileModel>();

    protected override void OnParametersSet()
    {
        CareerRecords = Person.CareerRecords
                              .Filter(Sport, OccupationType)
                              .Select(record => new CareerRecordProfileModel(record))
                              .OrderBy(record => record.CareerRecordTypeName)
                              .ToArray();
    }
}
