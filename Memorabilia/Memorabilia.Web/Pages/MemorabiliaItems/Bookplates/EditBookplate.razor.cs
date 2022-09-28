
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Memorabilia.Bookplate;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.Bookplates
{
    public partial class EditBookplate : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SaveBookplateViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SaveBookplateViewModel(await QueryRouter.Send(new GetBookplate.Query(MemorabiliaId)).ConfigureAwait(false))
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SaveBookplate.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }
    }
}
