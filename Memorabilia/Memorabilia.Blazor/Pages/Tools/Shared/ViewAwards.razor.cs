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
            ["DomainItems"] = AwardType.GetAll(Sport),
            ["Title"] = $"{Sport.Name} Awards"
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

        _ = int.TryParse(result.Data.ToString(), out int id);

        if (id == 0)
            return;

        var awardType = AwardType.Find(id);

        await Load(awardType);
    }

    private async Task Load(AwardType awardType)
    {
        if (awardType == null)
            return;

        Model = new(await QueryRouter.Send(new GetAwards(awardType, Sport)), Sport) 
                {
                    AwardType = awardType
                }; 
    }

    private async Task OnInputChange(AwardType awardType)
    {
        Model = new(await QueryRouter.Send(new GetAwards(awardType, Sport)), Sport)
                {
                    AwardType = awardType
                };
    }
}
