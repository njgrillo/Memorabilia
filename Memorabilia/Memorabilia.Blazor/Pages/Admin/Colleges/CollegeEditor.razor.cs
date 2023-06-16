namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class CollegeEditor 
    : EditDomainItem<College>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetCollege(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCollege(EditModel));
    }
}
