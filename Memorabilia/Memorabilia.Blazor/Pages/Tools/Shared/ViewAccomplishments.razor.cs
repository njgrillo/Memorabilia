namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAccomplishments 
    : ViewSportTools<AccomplishmentModel>
{
    protected AccomplishmentsModel Model 
        = new();

    protected async Task Browse()
    {
        var parameters = new DialogParameters
        {
            ["DomainItems"] = AccomplishmentType.GetAll(Sport),
            ["Title"] = $"{Sport.Name} Accomplishments"
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

        var accomplishmentType = AccomplishmentType.Find(id);

        await Load(accomplishmentType);
    }

    protected override bool FilterFunc(AccomplishmentModel model, string search)
    {
        bool canSearchByYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               (canSearchByYear && model.Year.HasValue && model.Year.Value == year)||
               model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.AccomplishmentTypeName.Contains(search) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.Name,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }

    private async Task Load(AccomplishmentType accomplishmentType)
    {
        if (accomplishmentType == null)
            return;  

        Model = new(await QueryRouter.Send(new GetAccomplishments(accomplishmentType, Sport)), Sport)
                {
                    AccomplishmentType = accomplishmentType
                };

        if (accomplishmentType != AccomplishmentType.NoHitter)
            return;

        AccomplishmentsModel perfectGames 
            = new(await QueryRouter.Send(new GetAccomplishments(AccomplishmentType.PerfectGame, Sport)), Sport)
              {
                  AccomplishmentType = AccomplishmentType.PerfectGame
              };

        AccomplishmentsModel combinedNoHitters
            = new(await QueryRouter.Send(new GetAccomplishments(AccomplishmentType.CombinedNoHitter, Sport)), Sport)
            {
                AccomplishmentType = AccomplishmentType.CombinedNoHitter
            };

        var otherNoHitters = perfectGames.PersonAccomplishments
                                         .Union(combinedNoHitters.PersonAccomplishments);

        Model.PersonAccomplishments.AddRange(otherNoHitters);
    }

    private async Task OnInputChange(AccomplishmentType accomplishmentType)
    {
        await Load(accomplishmentType);
    }    
}
