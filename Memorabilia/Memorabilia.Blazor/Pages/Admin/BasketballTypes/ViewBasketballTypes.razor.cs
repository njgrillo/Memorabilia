namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class ViewBasketballTypes 
    : ViewDomainItem<BasketballTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveBasketballType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BasketballTypesModel(await Mediator.Send(new GetBasketballTypes()));
    }
}
