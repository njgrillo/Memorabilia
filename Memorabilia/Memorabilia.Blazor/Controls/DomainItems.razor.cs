#nullable disable

namespace Memorabilia.Blazor.Controls
{
    public partial class DomainItems : ComponentBase
    {
        [Parameter]
        public DomainsViewModel Items
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }

        [Parameter]
        public EventCallback<SaveDomainViewModel> OnDelete { get; set; }

        [Parameter]
        public EventCallback OnLoad { get; set; }

        private DomainsViewModel _viewModel;

        protected async Task Delete(SaveDomainViewModel viewModel)
        {
            await OnDelete.InvokeAsync(viewModel).ConfigureAwait(false);
        }

        protected async Task Load()
        {
            await OnLoad.InvokeAsync().ConfigureAwait(false);
        }
    }
}
