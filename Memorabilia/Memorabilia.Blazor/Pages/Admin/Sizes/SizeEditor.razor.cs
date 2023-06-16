namespace Memorabilia.Blazor.Pages.Admin.Sizes;

public partial class SizeEditor 
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
