namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class SingleSeasonFranchiseRecordsProfile : SportProfile
{
    private SingleSeasonFranchiseRecordProfileModel[] SingleSeasonFranchiseRecords
        = [];

    protected override void OnParametersSet()
    {
        SingleSeasonFranchiseRecords 
            = Person.SingleSeasonFranchiseRecords
                    .Filter(Sport)
                    .Select(record => new SingleSeasonFranchiseRecordProfileModel(record))
                    .OrderBy(record => record.RecordTypeName)
                    .ToArray();
    }

    private bool Filter(SingleSeasonFranchiseRecordProfileModel model)
        => model.Filter(Search);
}
