namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class EditBasketballType
    : EditDomainItem<BasketballType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetBasketballType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBasketballType(EditModel));
    }
}
