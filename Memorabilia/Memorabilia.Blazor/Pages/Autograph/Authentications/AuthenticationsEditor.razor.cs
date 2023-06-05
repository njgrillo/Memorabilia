namespace Memorabilia.Blazor.Pages.Autograph.Authentications;

public partial class AuthenticationsEditor : AutographItem<AuthenticationEditModel>
{
    [Inject]
    public AuthenticationValidator Validator { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    private AuthenticationsEditModel AuthenticationsViewModel = new ();
    private bool _canAddAuthentication = true;
    private bool _canEditAuthenticationCompany = true;
    private bool _canUpdateAuthentication;     

    protected async Task OnLoad()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        AuthenticationsViewModel = new AuthenticationsEditModel(autograph.Authentications, 
                                                                autograph.ItemType, 
                                                                autograph.MemorabiliaId,
                                                                autograph.Id,
                                                                autograph.MemorabiliaImageNames);
    }

    protected async Task OnSave()
    {
        AuthenticationsViewModel.AutographId = AutographId;

        await CommandRouter.Send(new SaveAuthentications.Command(AuthenticationsViewModel));
    }

    private void AddAuthentication()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        AuthenticationsViewModel.Authentications.Add(ViewModel);

        ViewModel = new AuthenticationEditModel();
    }

    private void Edit(AuthenticationEditModel authentication)
    {
        ViewModel.AuthenticationCompanyId = authentication.AuthenticationCompanyId;
        ViewModel.HasHologram = authentication.HasHologram;
        ViewModel.HasLetter = authentication.HasLetter;
        ViewModel.Verification = authentication.Verification;
        ViewModel.Witnessed = authentication.Witnessed;

        _canAddAuthentication = false;
        _canEditAuthenticationCompany = false;
        _canUpdateAuthentication = true;
    }

    private void UpdateAuthentication()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        var authentication = AuthenticationsViewModel.Authentications
                                                     .Single(authentication => authentication.AuthenticationCompanyId == ViewModel.AuthenticationCompanyId);

        authentication.HasHologram = ViewModel.HasHologram;
        authentication.HasLetter = ViewModel.HasLetter;
        authentication.Verification = ViewModel.Verification;
        authentication.Witnessed = ViewModel.Witnessed;

        ViewModel = new AuthenticationEditModel();

        _canAddAuthentication = true;
        _canEditAuthenticationCompany = true;
        _canUpdateAuthentication = false;
    }
}
