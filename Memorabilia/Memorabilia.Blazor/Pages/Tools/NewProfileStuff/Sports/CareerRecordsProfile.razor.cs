namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class CareerRecordsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private CareerRecordProfileViewModel[] CareerRecords = Array.Empty<CareerRecordProfileViewModel>();

    protected override void OnParametersSet()
    {
        CareerRecords = Person.CareerRecords
                              .Filter(Sport)
                              .Select(record => new CareerRecordProfileViewModel(record))
                              .OrderBy(record => record.CareerRecordTypeName)
                              .ToArray();
    }
}
