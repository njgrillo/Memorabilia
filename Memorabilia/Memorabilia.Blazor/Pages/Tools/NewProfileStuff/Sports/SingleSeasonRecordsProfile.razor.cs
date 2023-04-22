namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class SingleSeasonRecordsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private SingleSeasonRecordProfileViewModel[] SingleSeasonRecords = Array.Empty<SingleSeasonRecordProfileViewModel>();   

    protected override void OnParametersSet()
    {
        SingleSeasonRecords = Person.SingleSeasonRecords
                                    .Filter(Sport)
                                    .Select(record => new SingleSeasonRecordProfileViewModel(record))
                                    .OrderBy(record => record.RecordTypeName)
                                    .ToArray();
    }
}
