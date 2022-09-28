using Memorabilia.Application.Features.Admin.WritingInstruments;

namespace Memorabilia.Web.Pages.Admin.WritingInstruments
{
    public partial class WritingInstruments : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private WritingInstrumentsViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveWritingInstrument.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetWritingInstruments.Query()).ConfigureAwait(false);
        }
    }
}
