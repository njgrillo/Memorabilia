namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class SingleSeasonRecordsProfile : SportProfile
{
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
