#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class BasketballTypeEditor : EditDomainItem<BasketballType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBasketballType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBasketballType.Command(ViewModel));
    }
}
