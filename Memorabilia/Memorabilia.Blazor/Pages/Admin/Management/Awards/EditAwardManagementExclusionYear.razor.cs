namespace Memorabilia.Blazor.Pages.Admin.Management.Awards;

public partial class EditAwardManagementExclusionYear
{
    [Parameter]
    public List<AwardExclusionYearEditModel> ExclusionYears { get; set; }
        = new();

    private string _years;

    protected EditModeType EditMode
        = EditModeType.Add;

    protected AwardExclusionYearEditModel EditModel
        = new();

    private void Add()
    {
        if (_years.IsNullOrEmpty())
            return;

        int[] years = _years.ToIntArray();

        if (!years.Any())
            return;

        foreach (int year in years)
        {
            ExclusionYears.Add(new AwardExclusionYearEditModel() { Reason = EditModel.Reason, Year = year });
        }

        EditModel = new();

        _years = string.Empty;
    }

    private void Edit(AwardExclusionYearEditModel awardExclusionYear)
    {
        EditModel.Reason = awardExclusionYear.Reason;
        EditModel.Year = awardExclusionYear.Year;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        AwardExclusionYearEditModel awardExclusionYear
            = ExclusionYears.Single(exclusionYear => exclusionYear.Year == EditModel.Year);

        awardExclusionYear.Reason = EditModel.Reason;
        awardExclusionYear.Year = EditModel.Year;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
