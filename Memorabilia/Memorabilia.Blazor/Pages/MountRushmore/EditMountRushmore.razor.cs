namespace Memorabilia.Blazor.Pages.MountRushmore;

public partial class EditMountRushmore
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public MountRushmoreValidator Validator { get; set; }

    [Parameter]
    public string EncryptId { get; set; }

    private List<PersonDragDropItem> AvailableMountRushmorePeople
        = [];    

    protected MountRushmoreEditModel EditModel
        = new();

    protected int Id;

    protected Entity.Person SelectedMountRushmorePerson { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    private MudDropContainer<PersonDragDropItem> _mountRushmoreContainer;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected override async Task OnInitializedAsync()
    {
        Id = DataProtectorService.DecryptId(EncryptId);

        if (Id == 0)
        {
            EditModel = new MountRushmoreEditModel
            {
                UserId = ApplicationStateService.CurrentUser.Id
            };

            return;
        }

        await Load();
    }

    private void AddMountRushmorePerson()
    {
        if (AvailableMountRushmorePeople.Where(mountRushmorePerson => !mountRushmorePerson.IsDeleted)
                                        .Any(item => item.Person.Id == SelectedMountRushmorePerson.Id))
            return;

        AvailableMountRushmorePeople.Add(new PersonDragDropItem 
        { 
            Identifier = "0", 
            ImageFileName = SelectedMountRushmorePerson.ImageFileName, 
            Person = SelectedMountRushmorePerson 
        });

        RefreshMountRushmoreContainer();

        SelectedMountRushmorePerson = new();
    }

    private async Task<Entity.Person> GetPerson(int personId)
    {
        return await Mediator.Send(new GetPerson(personId));
    }

    private async Task Load()
    {
        Entity.MountRushmore mountRushmore = await Mediator.Send(new GetMountRushmore(Id));

        EditModel = new MountRushmoreEditModel(mountRushmore);

        AvailableMountRushmorePeople 
            = EditModel.People
                       .Select(mountRushmorePerson => new PersonDragDropItem
                        {
                            Identifier = mountRushmorePerson.PositionId.ToString(),
                            Person = new Entity.Person { Id = mountRushmorePerson.PersonId }
                        })
                       .ToList();

        foreach (PersonDragDropItem mountRushmorePerson in AvailableMountRushmorePeople)
        {
            mountRushmorePerson.Person = await GetPerson(mountRushmorePerson.Person.Id);
            mountRushmorePerson.ImageFileName = mountRushmorePerson.Person.ImageFileName;
        }
    }

    private void MountRushmoreItemUpdated(MudItemDropInfo<PersonDragDropItem> dropItem)
    {
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;        

        MountRushmorePersonEditModel person 
            = EditModel.People.SingleOrDefault(person => person.PersonId == dropItem.Item.Person.Id);

        if (person != null && dropItem.Item.Identifier == "0")
        {
            person.IsDeleted = true;
            return;
        }

        _ = dropItem.Item.Identifier.TryParse(out int positionId);

        if (person == null)
        {            
            EditModel.People.Add(new MountRushmorePersonEditModel(EditModel.Id, dropItem.Item.Person.Id, positionId));
            return;
        }
        
        person.PositionId = positionId;
    }

    protected async Task OnSave()
    {
        var command = new SaveMountRushmore.Command(EditModel);        

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Mount Rushmore was saved successfully!", Severity.Success);

        Id = command.Id;

        await Load();
    }

    private void RefreshMountRushmoreContainer()
    {
        StateHasChanged();

        _mountRushmoreContainer.Refresh();
    }

    private void Remove(int personId)
    {
        MountRushmorePersonEditModel person
            = EditModel.People.SingleOrDefault(person => person.PersonId == personId);

        if (person == null)
            return;

        person.IsDeleted = true;

        RefreshMountRushmoreContainer();
    }
}
