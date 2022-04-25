using Demo.Framework.Web;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Autograph.Authentication;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Autograph.Authentications
{
    public partial class EditAuthentications : ComponentBase
    {
        [Parameter]
        public int AutographId { get; set; }

        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } 

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveAuthenticationsViewModel _authenticationsViewModel = new ();
        private bool _canAddAuthentication = true;
        private bool _canEditAuthenticationCompany = true;
        private bool _canUpdateAuthentication;
        private SaveAuthenticationViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId)).ConfigureAwait(false);

            _authenticationsViewModel = new SaveAuthenticationsViewModel(autograph.Authentications, 
                                                                         autograph.ItemType, 
                                                                         autograph.MemorabiliaId,
                                                                         autograph.Id);
        }

        protected async Task OnSave()
        {
            _authenticationsViewModel.AutographId = AutographId;

            await CommandRouter.Send(new SaveAuthentications.Command(_authenticationsViewModel)).ConfigureAwait(false);
        }

        private void AddAuthentication()
        {
            _authenticationsViewModel.Authentications.Add(_viewModel);
            _viewModel = new SaveAuthenticationViewModel();
        }

        private void Edit(SaveAuthenticationViewModel authentication)
        {
            _viewModel.AuthenticationCompanyId = authentication.AuthenticationCompanyId;
            _viewModel.HasHologram = authentication.HasHologram;
            _viewModel.HasLetter = authentication.HasLetter;
            _viewModel.Verification = authentication.Verification;
            _viewModel.Witnessed = authentication.Witnessed;

            _canAddAuthentication = false;
            _canEditAuthenticationCompany = false;
            _canUpdateAuthentication = true;
        }

        private void Remove(int authenticationCompanyId)
        {
            var authentication = _authenticationsViewModel.Authentications.Single(authentication => authentication.AuthenticationCompanyId == authenticationCompanyId);

            authentication.IsDeleted = true;
        }

        private void UpdateAuthentication()
        {
            var authentication = _authenticationsViewModel.Authentications.Single(authentication => authentication.AuthenticationCompanyId == _viewModel.AuthenticationCompanyId);

            authentication.HasHologram = _viewModel.HasHologram;
            authentication.HasLetter = _viewModel.HasLetter;
            authentication.Verification = _viewModel.Verification;
            authentication.Witnessed = _viewModel.Witnessed;

            _viewModel = new SaveAuthenticationViewModel();

            _canAddAuthentication = true;
            _canEditAuthenticationCompany = true;
            _canUpdateAuthentication = false;
        }
    }
}
