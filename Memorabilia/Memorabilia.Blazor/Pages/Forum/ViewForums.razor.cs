namespace Memorabilia.Blazor.Pages.Forum;

public partial class ViewForums
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }    

    protected ForumCategory SelectedCategory { get; set; }  
    
    protected Sport SelectedSport { get; set; }

    protected string SearchText { get; set; }

    private bool _canCreatePost;

    private string _searchText;

    protected override void OnInitialized()
    {
        _canCreatePost = ApplicationStateService.CurrentUser != null;
    }

    protected async Task Browse()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ForumCategoryBrowseDialog>(string.Empty, new DialogParameters(), options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        _ = result.Data.ToString().TryParse(out int id);

        if (id == 0)
            return;

        SelectedCategory = ForumCategory.Find(id);
    }

    protected void CreatePost()
    {
        NavigationManager.NavigateTo(NavigationPath.ForumCreateTopic);
    }

    private void OnCategoryChange(ForumCategory category)
    {
        SelectedCategory = category;
    }

    private void OnSportChange(Sport sport)
    {
        SelectedSport = sport;
    }    

    private void Search()
    {
        SearchText = _searchText;
    }
}
