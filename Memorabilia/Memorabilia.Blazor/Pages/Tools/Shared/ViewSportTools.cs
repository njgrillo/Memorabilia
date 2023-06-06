namespace Memorabilia.Blazor.Pages.Tools.Shared;

public abstract class ViewSportTools<T> : ImagePage where T : SportToolModel, IWithName
{
    [Parameter]
    public Sport Sport { get; set; }

    protected string Search;

    protected bool FilterFunc1(T viewModel) => FilterFunc(viewModel, Search);

    protected virtual bool FilterFunc(T viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               CultureInfo.CurrentCulture.CompareInfo.IndexOf(viewModel.Name,
                                                              search,
                                                              CompareOptions.IgnoreNonSpace) > -1;
    }
}
