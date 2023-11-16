using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Forum;

public partial class ViewForumBookmarks
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected ForumTopicsModel Model { get; set; }
        = new();

    private string _search;

    protected override async Task OnInitializedAsync()
    {
        Entity.ForumTopic[] forumTopics
            = await Mediator.Send(new GetBookmarkedForumTopics(ApplicationStateService.CurrentUser.Id));

        Model = new(forumTopics);
    }

    protected async Task Remove(int forumTopicId)
    {
        await Mediator.Send(new UpdateForumTopicBookmark(forumTopicId,
                                                              ApplicationStateService.CurrentUser.Id));

        Model.ForumTopics.RemoveAll(forumTopic => forumTopic.Id == forumTopicId);

        Snackbar.Add("Bookmark removed successfully!", Severity.Success);
    }

    protected async Task ShowRemoveBookmarkConfirm(int id)
    {
        var dialog = DialogService.Show<DeleteDialog>("Remove Bookmark");
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        await Remove(id);
    }

    private bool FilterFunc(ForumTopicModel model)
        => _search.IsNullOrEmpty() ||
           model.ForumCategoryName.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           model.Subject.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           model.CreatedByUsername.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           model.LastReplyByUsername.Contains(_search, StringComparison.OrdinalIgnoreCase) ||
           model.SportName.Contains(_search, StringComparison.OrdinalIgnoreCase);
}
