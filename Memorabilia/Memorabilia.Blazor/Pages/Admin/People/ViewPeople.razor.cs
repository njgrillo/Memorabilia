namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class ViewPeople 
    : ViewItem<PeopleModel, PersonModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = new PeopleModel(await QueryRouter.Send(new GetPeople()));
    }

    protected override async Task Delete(int id)
    {
        PersonModel deletedItem = Model.People.Single(person => person.Id == id);

        var editModel = new PersonEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePerson.Command(editModel));

        Model.People.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(PersonModel model, string search)
        => PersonFilterService.Filter(model, search);
}
