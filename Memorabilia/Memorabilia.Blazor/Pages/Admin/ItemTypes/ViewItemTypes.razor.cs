namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ViewItemTypes 
    : ViewDomainItem<ItemTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveItemType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypesModel(await Mediator.Send(new GetItemTypes()));
    }
}
