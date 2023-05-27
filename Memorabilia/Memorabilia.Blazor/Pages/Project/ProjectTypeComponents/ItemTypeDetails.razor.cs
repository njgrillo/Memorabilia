namespace Memorabilia.Blazor.Pages.Project.ProjectTypeComponents;

public partial class ItemTypeDetails
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public SaveProjectViewModel Model { get; set; }

    private bool _displayCompleted;

    private async Task AddProjectPerson()
    {
        var parameters = new DialogParameters
        {
            ["ItemTypeId"] = Model.Item.ItemTypeId,
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

        SaveProjectPersonViewModel projectPerson
            = (SaveProjectPersonViewModel)result.Data;

        //TODO: Add - Don't Link - Then link from grid - See HelmetTypeDetails

        Model.People.Add(projectPerson);
    }
}
