namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class CareerRecordsProfile : SportProfile
{
    private CareerRecordProfileViewModel[] CareerRecords = Array.Empty<CareerRecordProfileViewModel>();

    protected override void OnParametersSet()
    {
        CareerRecords = Person.CareerRecords
                              .Filter(Sport, OccupationType)
                              .Select(record => new CareerRecordProfileViewModel(record))
                              .OrderBy(record => record.CareerRecordTypeName)
                              .ToArray();
    }
}
