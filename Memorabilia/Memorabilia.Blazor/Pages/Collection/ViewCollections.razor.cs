using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Collection;

public partial class ViewCollections
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected CollectionsModel Model 
        = new();

    protected override async Task OnInitializedAsync()
    {
        Entity.Collection[] collections 
            = await Mediator.Send(new GetCollections());

        Model = new CollectionsModel(collections);
    }

    protected async Task Delete(int id)
    {
        CollectionModel deletedItem 
            = Model.Collections.Single(collection => collection.Id == id);

        var model = new CollectionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveCollection.Command(model));

        Model.Collections.Remove(deletedItem);

        Snackbar.Add("Collection was deleted successfully!", Severity.Success);
    }
}
