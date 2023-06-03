namespace Memorabilia.Blazor.Pages.Collection;

public partial class CollectionMemorabiliaGrid
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public List<CollectionMemorabiliaEditModel> Items { get; set; } = new();

    private string _search;

    private bool FilterFunc1(CollectionMemorabiliaEditModel collectionMemorabiliaViewModel)
        => FilterFunc(collectionMemorabiliaViewModel, _search);

    private static bool FilterFunc(CollectionMemorabiliaEditModel collectionMemorabiliaViewModel, string search)
    {
        return search.IsNullOrEmpty();

        //return search.IsNullOrEmpty() ||
        //       projectPersonViewModel.PriorityTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
        //       projectPersonViewModel.ProjectStatusTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
        //       projectPersonViewModel.Person.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
        //       (!projectPersonViewModel.Person.Nickname.IsNullOrEmpty() && projectPersonViewModel.Person.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    private void Remove(int id, int memorabiliaId)
    {
        var item = id > 0
            ? Items.Single(item => item.Id == id)
            : Items.Single(item => item.MemorabiliaId == memorabiliaId);

        item.IsDeleted = true;
    }
}
