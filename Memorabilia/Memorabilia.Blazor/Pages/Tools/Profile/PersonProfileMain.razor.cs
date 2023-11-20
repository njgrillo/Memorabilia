namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfileMain
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public string EncryptedPersonId { get; set; }

    protected PersonProfileModel Model;

    protected int PersonId;

    private Entity.Person _person;    

    protected override async Task OnParametersSetAsync()
    {
        PersonId = DataProtectorService.DecryptId(EncryptedPersonId);

        if (PersonId == 0)
            return;

        _person = await Mediator.Send(new GetPerson(PersonId));

        Model = new PersonProfileModel(_person);
    }
}
