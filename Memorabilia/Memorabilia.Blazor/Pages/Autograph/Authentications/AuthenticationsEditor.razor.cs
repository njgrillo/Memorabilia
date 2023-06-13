namespace Memorabilia.Blazor.Pages.Autograph.Authentications;

public partial class AuthenticationsEditor 
    : AutographItem<AuthenticationEditModel>
{
    [Inject]
    public AuthenticationValidator Validator { get; set; }

    protected AuthenticationsEditModel EditModel 
        = new();

    private bool _canAddAuthentication 
        = true;

    private bool _canEditAuthenticationCompany 
        = true;

    private bool _canUpdateAuthentication;     

    protected async Task OnLoad()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        EditModel = new AuthenticationsEditModel(autograph.Authentications, 
                                                 autograph.ItemType, 
                                                 autograph.UserId,
                                                 autograph.MemorabiliaId,
                                                 autograph.Id,
                                                 autograph.MemorabiliaImageNames);
    }

    protected async Task OnSave()
    {
        EditModel.AutographId = AutographId;

        await CommandRouter.Send(new SaveAuthentications.Command(EditModel));
    }

    private void AddAuthentication()
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

        _canAddAuthentication = false;
        _canEditAuthenticationCompany = false;
        _canUpdateAuthentication = true;
    }

    private void UpdateAuthentication()
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

        _canAddAuthentication = true;
        _canEditAuthenticationCompany = true;
        _canUpdateAuthentication = false;
    }
}
