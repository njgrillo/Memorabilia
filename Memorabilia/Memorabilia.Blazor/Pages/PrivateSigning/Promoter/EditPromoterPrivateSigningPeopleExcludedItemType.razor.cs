namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPeopleExcludedItemType
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
        = [];    

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonExcludeItemTypeEditModel EditModel { get; set; }
        = new();

    protected List<PrivateSigningPersonExcludeItemTypeEditModel> Items
        => People.Count != 0
            ?  People.SelectMany(person => person.ExcludedItems)
                     .Where(item => !item.IsDeleted)
                     .OrderBy(item => item.Person.DisplayName)
                     .ThenBy(item => item.ItemType?.Name)
                     .ToList()
            : [];

    protected void Add()
    {
        if (EditModel.Person == null || EditModel.Person.Id == 0)
            return;

        PrivateSigningPersonEditModel editModel 
            = People.Single(person => person.Person.Id == EditModel.Person.Id);

        editModel.ExcludedItems.Add(EditModel);

        EditModel = new();
    }

    protected PersonModel GetPerson(int personId)
       => People.Single(privateSigningPerson => privateSigningPerson.Person.Id == personId).Person;
}
