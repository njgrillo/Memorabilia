namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPersonPrice
{
    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
       = [];

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonDetailEditModel EditModel { get; set; }
        = new();

    protected void Add()
    {
        if (EditModel.Person.Id == 0 || EditModel.PrivateSigningItemTypeGroupId == 0)
            return;

        PrivateSigningPersonEditModel person 
            = People.Single(privateSigningPerson => privateSigningPerson.Person.Id == EditModel.Person.Id);

        person.Pricing.Add(EditModel);

        EditModel = new();
    }

    protected void Edit(PrivateSigningPersonDetailEditModel editModel)
    {       
        EditModel.Cost = editModel.Cost;
        EditModel.Note = editModel.Note;
        EditModel.Person = editModel.Person;
        EditModel.PrivateSigningItemGroup = editModel.PrivateSigningItemGroup;        

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
        editModel.PrivateSigningItemGroup = EditModel.PrivateSigningItemGroup;        

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
