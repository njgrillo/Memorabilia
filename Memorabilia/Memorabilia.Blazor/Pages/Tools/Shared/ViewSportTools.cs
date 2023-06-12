namespace Memorabilia.Blazor.Pages.Tools.Shared;

public abstract class ViewSportTools<T> 
    : ComponentBase where T : SportToolModel, IWithName
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    protected string Search;

    protected bool FilterFunc1(T model) 
        => FilterFunc(model, Search);

    protected virtual bool FilterFunc(T model, string search)
        => search.IsNullOrEmpty() ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(model.Name,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;

    protected async Task ShowPersonProfileDialog(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
    }
}
