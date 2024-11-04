namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class CareerFranchiseRecordsProfile : SportProfile
{
    private CareerFranchiseRecordProfileModel[] CareerFranchiseRecords
        = [];

    protected override void OnParametersSet()
    {
        CareerFranchiseRecords 
            = Person.CareerFranchiseRecords
                    .Filter(Sport, OccupationType)
                    .Select(record => new CareerFranchiseRecordProfileModel(record))
                    .OrderBy(record => record.CareerRecordTypeName)
                    .ToArray();
    }

    private bool Filter(CareerFranchiseRecordProfileModel model)
        => model.Filter(Search);
}
