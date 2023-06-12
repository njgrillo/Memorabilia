﻿namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAccomplishments 
    : ViewSportTools<AccomplishmentModel>
{
    protected AccomplishmentsModel Model = new();

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

        _ = int.TryParse(result.Data.ToString(), out int id);

        if (id == 0)
            return;

        var accomplishmentType = AccomplishmentType.Find(id);

        await Load(accomplishmentType);
    }

    protected override bool FilterFunc(AccomplishmentModel viewModel, string search)
    {
        bool canSearchByYear = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (canSearchByYear && viewModel.Year.HasValue && viewModel.Year.Value == year)||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.AccomplishmentTypeName.Contains(search) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.Name,
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
