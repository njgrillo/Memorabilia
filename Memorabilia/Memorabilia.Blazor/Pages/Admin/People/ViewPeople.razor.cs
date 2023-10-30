namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class ViewPeople 
    : ViewItem<PeopleModel, PersonModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = new PeopleModel(await Mediator.Send(new GetPeople()));
    }

    protected override async Task Delete(int id)
    {
        PersonModel deletedItem = Model.People.Single(person => person.Id == id);

        var editModel = new PersonEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SavePerson.Command(editModel));

        Model.People.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(PersonModel model, string search)
        => PersonFilterService.Filter(model, search);

    private async Task ShowPersonProfile(int personId)
    {
        var parameters = new DialogParameters
        {
            ["PersonId"] = personId
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        await dialog.Result;
    }
}
