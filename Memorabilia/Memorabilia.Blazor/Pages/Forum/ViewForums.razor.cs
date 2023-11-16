namespace Memorabilia.Blazor.Pages.Forum;

public partial class ViewForums : ReroutePage
{
    protected ForumCategory SelectedCategory { get; set; }  
    
    protected Sport SelectedSport { get; set; }

    protected string SearchText { get; set; }

    private bool _canInteract;

    private string _search;

    protected override void OnInitialized()
    {
        _canInteract
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.EditForum);
    }

    protected async Task Browse()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ForumCategoryBrowseDialog>(string.Empty, [], options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        _ = result.Data.ToString().TryParse(out int id);

        if (id == 0)
            return;

        SelectedCategory = ForumCategory.Find(id);
    }

    protected async Task CreatePost()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        NavigationManager.NavigateTo(NavigationPath.ForumCreateTopic);
    }

    private void OnSportChange(Sport sport)
    {
        SelectedSport = sport;
    }    

    private void Search()
    {
        SearchText = _search;
    }
}
