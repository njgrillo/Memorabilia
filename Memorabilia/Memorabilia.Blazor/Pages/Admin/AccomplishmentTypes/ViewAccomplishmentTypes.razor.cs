#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AccomplishmentTypes
{
    public partial class ViewAccomplishmentTypes : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        private AccomplishmentTypesViewModel _viewModel;

        protected async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await CommandRouter.Send(new SaveAccomplishmentType.Command(viewModel)).ConfigureAwait(false);
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetAccomplishmentTypes.Query()).ConfigureAwait(false);
        }
    }
}
