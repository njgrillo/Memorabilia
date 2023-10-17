namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ViewItemTypeSports 
    : ViewItem<ItemTypeSportsModel, ItemTypeSportModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypeSportsModel(await Mediator.Send(new GetItemTypeSports()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeSportModel deletedItem 
            = Model.ItemTypeSports.Single(ItemTypeSport => ItemTypeSport.Id == id);

        var editModel = new ItemTypeSportEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveItemTypeSport(editModel));

        Model.ItemTypeSports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSportModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.SportName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
