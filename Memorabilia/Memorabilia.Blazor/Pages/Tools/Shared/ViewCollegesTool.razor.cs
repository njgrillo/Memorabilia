namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewCollegesTool 
    : ViewSportTools<PersonCollegeModel>
{
    protected PersonCollegesModel Model
        = new();

    protected async Task Browse()
    {
        var parameters = new DialogParameters
        {
            ["DomainItems"] = College.All,
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

        _ = result.Data.ToString().TryParse(out int id);

        if (id == 0)
            return;

        var college = College.Find(id);

        await Load(college);
    }

    private async Task Load(College college)
    {
        if (college == null)
            return;

        Model = new(await Mediator.Send(new GetPersonColleges(college, Sport)), Sport)
                {
                    College = college
                };
    }

    private async Task OnInputChange(College college)
    {
        Model = new(await Mediator.Send(new GetPersonColleges(college, Sport)), Sport)
                {
                    College = college
                };
    }
}
