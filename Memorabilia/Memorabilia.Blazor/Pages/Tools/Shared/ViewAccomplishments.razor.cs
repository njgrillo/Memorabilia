namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAccomplishments 
    : ViewSportTools<AccomplishmentViewModel>
{
    [Inject]
    public IDialogService DialogService { get; set; }

    private AccomplishmentsViewModel _viewModel = new();

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
        var dialog = DialogService.Show<DomainItemBrowseDialog>("Accomplishments", parameters, options);
        var result = await dialog.Result;

        if (result.Cancelled)
            return;

        int.TryParse(result.Data.ToString(), out int id);

        if (id == 0)
            return;

        var accomplishmentType = AccomplishmentType.Find(id);

        await Load(accomplishmentType);
    }

    protected override bool FilterFunc(AccomplishmentViewModel viewModel, string search)
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

        _viewModel = await QueryRouter.Send(new GetAccomplishments(accomplishmentType, Sport));

        if (accomplishmentType != AccomplishmentType.NoHitter)
            return;

        var perfectGames = await QueryRouter.Send(new GetAccomplishments(AccomplishmentType.PerfectGame, Sport));
        var combinedNoHitters = await QueryRouter.Send(new GetAccomplishments(AccomplishmentType.CombinedNoHitter, Sport));
        var otherNoHitters = perfectGames.PersonAccomplishments.Union(combinedNoHitters.PersonAccomplishments);

        _viewModel.PersonAccomplishments.AddRange(otherNoHitters);
    }

    private async Task OnInputChange(AccomplishmentType accomplishmentType)
    {
        await Load(accomplishmentType);
    }    
}
