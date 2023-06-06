namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class SingleSeasonRecordsProfile : SportProfile
{
    private SingleSeasonRecordProfileModel[] SingleSeasonRecords = Array.Empty<SingleSeasonRecordProfileModel>();   

    protected override void OnParametersSet()
    {
        SingleSeasonRecords = Person.SingleSeasonRecords
                                    .Filter(Sport)
                                    .Select(record => new SingleSeasonRecordProfileModel(record))
                                    .OrderBy(record => record.RecordTypeName)
                                    .ToArray();
    }
}
