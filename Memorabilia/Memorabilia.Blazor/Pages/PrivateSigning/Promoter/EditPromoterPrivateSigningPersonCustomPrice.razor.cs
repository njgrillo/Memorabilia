namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPersonCustomPrice
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
       = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonDetailEditModel EditModel { get; set; }
        = new();

    protected void Add()
    {
        if (EditModel.Person.Id == 0 || EditModel.PrivateSigningCustomItemTypeGroupDetailId == 0)
            return;

        PrivateSigningPersonEditModel person
            = People.Single(privateSigningPerson => privateSigningPerson.Person.Id == EditModel.Person.Id);

        person.Pricing.Add(EditModel);

        EditModel = new();
    }

    protected async Task AddCustomGroup()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PromoterPrivateSigningCustomItemGroupDialog>(string.Empty,
                                                                                     new DialogParameters(),
                                                                                     options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;
    }

    protected void Edit(PrivateSigningPersonDetailEditModel editModel)
    {
        EditModel.Cost = editModel.Cost;
        EditModel.Note = editModel.Note;
        EditModel.Person = editModel.Person;
        EditModel.PrivateSigningCustomItemTypeGroupDetail = editModel.PrivateSigningCustomItemTypeGroupDetail;

        EditMode = EditModeType.Update;
    }

    protected PersonModel GetPerson(int personId)
       => People.Single(privateSigningPerson => privateSigningPerson.Person.Id == personId).Person;    

    protected void Update()
    {
        PrivateSigningPersonDetailEditModel editModel
            = People.SelectMany(person => person.Pricing)
                    .Single(pricing => pricing.Person.Id == EditModel.Person.Id && ((pricing.Id > 0 && pricing.Id == EditModel.Id) || (pricing.PrivateSigningItemGroup.Id == EditModel.PrivateSigningItemGroup.Id)));

        editModel.Cost = EditModel.Cost;
        editModel.Note = EditModel.Note;
        editModel.PrivateSigningCustomItemTypeGroupDetail = EditModel.PrivateSigningCustomItemTypeGroupDetail;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
