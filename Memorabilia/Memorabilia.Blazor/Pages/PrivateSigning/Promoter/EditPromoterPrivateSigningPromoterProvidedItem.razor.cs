namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPromoterProvidedItem
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public List<PromoterProvidedItemEditModel> ProvidedItems { get; set; }
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PromoterProvidedItemEditModel EditModel { get; set; }
        = new();

    protected void Add()
    {
        if (EditModel.ItemType == null)
            return;

        EditModel.PromoterId = ApplicationStateService.CurrentUser.Id;

        ProvidedItems.Add(EditModel);

        EditModel = new();
    }

    protected void Edit(PromoterProvidedItemEditModel editModel)
    {
        EditModel.ItemType = editModel.ItemType;
        EditModel.Cost = editModel.Cost;

        EditMode = EditModeType.Update;
    }

    protected void Update()
    {
        PromoterProvidedItemEditModel editModel
            = ProvidedItems.Single(item => item.ItemType.Id == EditModel.ItemType.Id);

        editModel.Cost = EditModel.Cost;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
