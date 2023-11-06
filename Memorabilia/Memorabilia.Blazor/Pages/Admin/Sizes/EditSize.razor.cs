namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class EditSize 
    : EditDomainItem<Constant.Size>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetSize(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveSize(EditModel));
    }
}
