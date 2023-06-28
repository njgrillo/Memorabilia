namespace Memorabilia.Blazor.Pages.Autograph.Authentications;

public partial class AuthenticationsEditor 
    : AutographItem<AuthenticationEditModel>
{
    [Inject]
    public AuthenticationValidator Validator { get; set; }

    protected AuthenticationsEditModel EditModel 
        = new();  

    protected override async Task OnInitializedAsync()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

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

        await CommandRouter.Send(new SaveAuthentications.Command(EditModel));
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
