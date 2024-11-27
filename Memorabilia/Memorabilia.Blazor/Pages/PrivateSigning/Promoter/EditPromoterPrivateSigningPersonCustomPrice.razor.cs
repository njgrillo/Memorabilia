namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPersonCustomPrice
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
       = [];

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonDetailEditModel EditModel { get; set; }
        = new();

    protected bool ReloadCustomItemTypes { get; set; }

    protected void Add()
    {
        if (EditModel.Person.Id == 0 || EditModel.PrivateSigningCustomItemTypeGroupDetailId == 0)
            return;

        PrivateSigningPersonEditModel person
            = People.Single(privateSigningPerson => privateSigningPerson.Person.Id == EditModel.Person.Id);

        EditModel.IsCustomType = true;

        person.Pricing.Add(EditModel);

        EditModel = new();
    }    

    protected void Edit(PrivateSigningPersonDetailEditModel editModel)
    {
        EditModel.Cost = editModel.Cost;
        EditModel.Id = editModel.Id;
        EditModel.Note = editModel.Note;
        EditModel.Person = editModel.Person;
        EditModel.PrivateSigningCustomItemTypeGroupDetail = editModel.PrivateSigningCustomItemTypeGroupDetail;
        EditModel.ShippingCost = editModel.ShippingCost;

        EditMode = EditModeType.Update;
    }

    protected PersonModel GetPerson(int personId)
       => People.Single(privateSigningPerson => privateSigningPerson.Person.Id == personId).Person;

    protected void OnCustomItemGroupsReloaded()
    {
        ReloadCustomItemTypes = false;
    }

    protected async Task OnSelectCustomItemTypesClick()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PromoterPrivateSigningCustomItemGroupDialog>(
            string.Empty,
            [],
            options
            );

        var result = await dialog.Result;

        if (result.Canceled)
            return;

        ReloadCustomItemTypes = true;

        if (result.Data is null)
            return;

        var privateSigningCustomItemGroup = (CustomItemGroupEditModel)result.Data;

        var item = new Entity.PrivateSigningCustomItemGroup(
            privateSigningCustomItemGroup.Name,
            privateSigningCustomItemGroup.Id,
            privateSigningCustomItemGroup
                .Items
                .Select(x => new Entity.PrivateSigningCustomItemTypeGroup(x.Id, x.ItemType.Id, privateSigningCustomItemGroup.Id)).ToArray()
            );

        EditModel.PrivateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup = item;
    }

    protected async Task OnViewCustomItemTypesClick()
    {
        var parameters = new DialogParameters
        {
            ["PrivateSigningCustomItemGroupId"] = EditModel.PrivateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ViewCustomItemGroupDialog>(
            string.Empty,
            parameters,
            options
            );

        await dialog.Result;
    }

    protected void Update()
    {
        PrivateSigningPersonDetailEditModel editModel
            = People.SelectMany(person => person.Pricing)
                    .Where(pricing => pricing.IsCustomType)
                    .Single(pricing => pricing.Person.Id == EditModel.Person.Id && ((pricing.Id > 0 && pricing.Id == EditModel.Id) || (pricing.PrivateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup.Id == EditModel.PrivateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup.Id)));

        editModel.Cost = EditModel.Cost;
        editModel.Note = EditModel.Note;
        editModel.PrivateSigningCustomItemTypeGroupDetail = EditModel.PrivateSigningCustomItemTypeGroupDetail;
        editModel.ShippingCost = EditModel.ShippingCost;

        EditModel = new();

        EditMode = EditModeType.Add;
    }    
}
