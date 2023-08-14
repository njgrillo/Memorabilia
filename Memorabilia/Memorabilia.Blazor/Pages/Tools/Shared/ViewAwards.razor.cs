namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAwards 
    : ViewSportTools<AwardModel>
{
    protected AwardsModel Model 
        = new();

    protected async Task Browse()
    {
        var parameters = new DialogParameters
        {
            ["DomainItems"] = Sport == null ? AwardType.MultiSport : AwardType.GetAll(false, Sport),
            ["Title"] = $"{Sport?.Name ?? "Multi Sport"} Awards"
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<DomainItemBrowseDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        _ = result.Data.ToString().TryParse(out int id);

        if (id == 0)
            return;

        var awardType = AwardType.Find(id);

        await Load(awardType);
    }

    private async Task GetAwardDetails(AwardType awardType)
    {
        Model = new(await QueryRouter.Send(new GetAwards(awardType, Sport)), Sport)
        {
            AwardType = awardType
        };

        Entity.AwardDetail awardDetail = await QueryRouter.Send(new GetAwardManagement(awardType.Id));

        if (awardDetail?.ExclusionYears.Any() ?? false)
        {
            Model.AwardExclusionYears = awardDetail.ExclusionYears.ToArray();
        }
    }

    private async Task Load(AwardType awardType)
    {
        if (awardType == null)
            return;        

        await GetAwardDetails(awardType);
    }

    private async Task OnInputChange(AwardType awardType)
    {
        await GetAwardDetails(awardType);
    }    
}
