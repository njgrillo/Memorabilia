namespace Memorabilia.Blazor.Pages.Autograph.Authentications;

public partial class EditAuthentications
    : AutographItem<AuthenticationEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public AuthenticationValidator Validator { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    protected AuthenticationsEditModel EditModel 
        = new();

    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);

        var autograph = new AutographModel(await Mediator.Send(new GetAutograph(AutographId)));

        EditModel = new AuthenticationsEditModel(autograph.Authentications,
                                                 autograph.ItemType,
                                                 autograph.UserId,
                                                 autograph.MemorabiliaId,
                                                 autograph.Id,
                                                 autograph.MemorabiliaImageNames);

        IsLoaded = true;
    }

    protected async Task Save()
    {
        EditModel.AutographId = AutographId;

        await Mediator.Send(new SaveAuthentications.Command(EditModel));

        _continueNavigationPath = EditModel.CanHaveSpot
            ? $"{NavigationPath.Autographs}/{AdminDomainItem.Spots.Item}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}"
            : $"{NavigationPath.AutographImage}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}";
    }

    private void Add()
    {
        Model.ValidationResult = Validator.Validate(Model);

        if (!Model.ValidationResult.IsValid)
            return;

        EditModel.Authentications.Add(Model);        

        Model = new();
    }

    private void Edit(AuthenticationEditModel authentication)
    {
        Model.AuthenticationCompanyId = authentication.AuthenticationCompanyId;
        Model.HasHologram = authentication.HasHologram;
        Model.HasLetter = authentication.HasLetter;
        Model.Verification = authentication.Verification;
        Model.Witnessed = authentication.Witnessed;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        Model.ValidationResult = Validator.Validate(Model);

        if (!Model.ValidationResult.IsValid)
            return;

        AuthenticationEditModel authentication 
            = EditModel.Authentications
                       .Single(authentication => authentication.AuthenticationCompanyId == Model.AuthenticationCompanyId);

        authentication.HasHologram = Model.HasHologram;
        authentication.HasLetter = Model.HasLetter;
        authentication.Verification = Model.Verification;
        authentication.Witnessed = Model.Witnessed;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
