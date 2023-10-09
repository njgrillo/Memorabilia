namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningPeopleExcludedItemTypeEditor
{
    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
        = new();

    protected PersonModel[] AvailablePeople
        => People.Any()
            ? People.Select(person => person.Person)
                    .ToArray()
            : Array.Empty<PersonModel>();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonExcludeItemTypeEditModel EditModel { get; set; }
        = new();

    protected List<PrivateSigningPersonExcludeItemTypeEditModel> Items
        => People.Any()
            ?  People.SelectMany(person => person.ExcludedItems)
                     .Where(item => !item.IsDeleted)
                     .OrderBy(item => item.Person.DisplayName)
                     .ThenBy(item => item.ItemType?.Name)
                     .ToList()
            : new();

    protected void Add()
    {
        if (EditModel.Person == null || EditModel.Person.Id == 0)
            return;

        PrivateSigningPersonEditModel editModel 
            = People.Single(person => person.Person.Id == EditModel.Person.Id);

        editModel.ExcludedItems.Add(EditModel);

        EditModel = new();
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }
}
