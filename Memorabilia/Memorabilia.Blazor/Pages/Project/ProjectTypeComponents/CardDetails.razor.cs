namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class CardDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public ProjectEditModel Model { get; set; }

    protected static int ItemTypeId 
        => ItemType.TradingCard.Id;

    private bool _displayCompleted;

    private async Task AddProjectPerson()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = ItemType.TradingCard.Id,
            ["MaxRank"] = Model.People.Any() ? Model.People.Max(person => person.Rank) + 1 : 1,
            ["ProjectId"] = Model.Id,
            ["UserId"] = Model.UserId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddProjectPersonDialog>("Add Project Person", parameters, options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ProjectPersonEditModel projectPerson
            = (ProjectPersonEditModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid - See HelmetTypeDetails

        Model.People.Add(projectPerson);
    }
}
