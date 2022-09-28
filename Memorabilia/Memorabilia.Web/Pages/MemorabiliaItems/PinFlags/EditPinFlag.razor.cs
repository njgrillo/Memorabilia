
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Memorabilia.PinFlag;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems.PinFlags
{
    public partial class EditPinFlag : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Parameter]
        public int MemorabiliaId { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private SavePinFlagViewModel _viewModel = new();

        protected async Task OnLoad()
        {
            _viewModel = new SavePinFlagViewModel(await QueryRouter.Send(new GetPinFlag.Query(MemorabiliaId)).ConfigureAwait(false))
            {
                MemorabiliaId = MemorabiliaId
            };
        }

        protected async Task OnSave()
        {
            await CommandRouter.Send(new SavePinFlag.Command(_viewModel)).ConfigureAwait(false);
        }

        private void SelectedPersonChanged(SavePersonViewModel person)
        {
            _viewModel.Person = person;
        }
    }
}
