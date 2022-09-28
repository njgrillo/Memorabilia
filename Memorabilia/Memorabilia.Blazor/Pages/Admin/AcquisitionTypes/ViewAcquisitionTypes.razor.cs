#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes
{
    public partial class ViewAcquisitionTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AcquisitionTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveAcquisitionType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetAcquisitionTypes.Query()).ConfigureAwait(false);
        }
    }
}
