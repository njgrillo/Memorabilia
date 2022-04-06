using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.Commissioners;
using Memorabilia.Application.Features.Admin.People;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Commissioners
{
    public partial class EditCommissioner : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int Id { get; set; }

        private IEnumerable<PersonViewModel> _people = Enumerable.Empty<PersonViewModel>();
        private SaveCommissionerViewModel _viewModel = new ();

        protected async Task HandleValidSubmit()
        {
            await CommandRouter.Send(new SaveCommissioner.Command(_viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            await LoadPeople().ConfigureAwait(false);

            if (Id == 0)
                return;

            _viewModel = new SaveCommissionerViewModel(await QueryRouter.Send(new GetCommissioner.Query(Id)).ConfigureAwait(false));
        }

        private async Task LoadPeople()
        {
            _people = (await QueryRouter.Send(new GetPeople.Query()).ConfigureAwait(false)).People;
        }

        private async Task<IEnumerable<PersonViewModel>> SearchPeople(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<PersonViewModel>();

            return await Task.FromResult(_people.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
        }
    }
}
