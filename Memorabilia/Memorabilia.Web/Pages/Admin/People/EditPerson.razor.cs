

using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.People
{
    public partial class EditPerson : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SavePersonViewModel _viewModel = new ();        

        protected async Task OnLoad()
        {
            if (Id == 0)
                return;

            _viewModel = new SavePersonViewModel(await QueryRouter.Send(new GetPerson.Query(Id)).ConfigureAwait(false));
        }

        protected async Task OnSave()
        {
            var command = new SavePerson.Command(_viewModel);

            await CommandRouter.Send(command).ConfigureAwait(false);

            _viewModel.Id = command.Id;
        }

        public void OnNameFieldBlur()
        {
            _viewModel.DisplayName = $"{_viewModel.LastName}"
                                    + (!_viewModel.Suffix.IsNullOrEmpty() ? $" {_viewModel.Suffix}," : ",")
                                    + (!_viewModel.Nickname.IsNullOrEmpty() ? $" {_viewModel.Nickname}" : $" {_viewModel.FirstName}");

            _viewModel.ProfileName = $"{(!_viewModel.Nickname.IsNullOrEmpty() ? _viewModel.Nickname : _viewModel.FirstName)}"
                                   + $" {_viewModel.LastName}"
                                   + (!_viewModel.Suffix.IsNullOrEmpty() ? $" {_viewModel.Suffix}" : string.Empty);

            _viewModel.LegalName = $"{_viewModel.FirstName}"
                                    + (!_viewModel.MiddleName.IsNullOrEmpty() ? $" {_viewModel.MiddleName}" : string.Empty)
                                    + (!_viewModel.LastName.IsNullOrEmpty() ? $" {_viewModel.LastName}" : string.Empty);
        }
    }
}
