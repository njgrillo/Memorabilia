#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph.Authentications;

public partial class AuthenticationsEditor : AutographItem<SaveAuthenticationViewModel>
{
    private SaveAuthenticationsViewModel AuthenticationsViewModel = new ();
    private bool _canAddAuthentication = true;
    private bool _canEditAuthenticationCompany = true;
    private bool _canUpdateAuthentication;     

    protected async Task OnLoad()
    {
        var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId));

        AuthenticationsViewModel = new SaveAuthenticationsViewModel(autograph.Authentications, 
                                                                     autograph.ItemType, 
                                                                     autograph.MemorabiliaId,
                                                                     autograph.Id);
    }

    protected async Task OnSave()
    {
        AuthenticationsViewModel.AutographId = AutographId;

        await CommandRouter.Send(new SaveAuthentications.Command(AuthenticationsViewModel));
    }

    private void AddAuthentication()
    {
        AuthenticationsViewModel.Authentications.Add(ViewModel);

        ViewModel = new SaveAuthenticationViewModel();
    }

    private void Edit(SaveAuthenticationViewModel authentication)
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

    private void Remove(int authenticationCompanyId)
    {
        var authentication = AuthenticationsViewModel.Authentications.Single(authentication => authentication.AuthenticationCompanyId == authenticationCompanyId);

        authentication.IsDeleted = true;
    }

    private void UpdateAuthentication()
    {
        var authentication = AuthenticationsViewModel.Authentications.Single(authentication => authentication.AuthenticationCompanyId == ViewModel.AuthenticationCompanyId);

        authentication.HasHologram = ViewModel.HasHologram;
        authentication.HasLetter = ViewModel.HasLetter;
        authentication.Verification = ViewModel.Verification;
        authentication.Witnessed = ViewModel.Witnessed;

        ViewModel = new SaveAuthenticationViewModel();

        _canAddAuthentication = true;
        _canEditAuthenticationCompany = true;
        _canUpdateAuthentication = false;
    }
}
